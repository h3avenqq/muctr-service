import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_html/flutter_html.dart';
import 'package:mob_app/models/postProfessor.dart';
import 'package:mob_app/views/department_view.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:html/dom.dart' as dom;
import 'package:flutter/material.dart';
import 'package:mob_app/accordion_professors.dart';
import 'package:mob_app/models/postDepartment.dart';
import 'package:mob_app/models/postFaculty.dart';
import '../accordion.dart';
import 'package:http/http.dart' as http;



class AccordionProfessors extends StatefulWidget {
  final String title;
  final String id;
  final String dep_id;

  const AccordionProfessors({Key? key, required this.title, required this.id, required this.dep_id})
      : super(key: key);
  @override
  _AccordionProfessorsState createState() => _AccordionProfessorsState();
}

class _AccordionProfessorsState extends State<AccordionProfessors> {
  bool _showContent = false;
  @override
  Widget build(BuildContext context) {
    return Card(
      margin: const EdgeInsets.all(10),
      child: Column(children: [
        ListTile(
          title: Text(widget.title),
          trailing: IconButton(
            icon: Icon(
                _showContent ? Icons.arrow_drop_up : Icons.arrow_drop_down),
            onPressed: () {
              setState(() {
                _showContent = !_showContent;
              });
            },
          ),
        ),
        _showContent
            ? Container(
            padding:
            const EdgeInsets.symmetric(vertical: 15, horizontal: 15),
            child: Column(
              children: [
                PageOfProfessor(id_caf: widget.id, titles: widget.title, id_dep: widget.dep_id,)



              ],
            )
        )
            : Container()
      ]),
    );
  }
}

List<Professor> list_professor = [];
var isLoaded_professor = false;
List<int> list_selected_professor = [];

class PageOfProfessor extends StatefulWidget {
  final String titles ;
  final String id_caf;
  final String id_dep;
  const PageOfProfessor({Key? key, required this.titles, required this.id_caf, required this.id_dep}) : super(key: key);

  @override
  State<PageOfProfessor> createState() => _PageOfProfessorState();
}

class _PageOfProfessorState extends State<PageOfProfessor> {
  Future<bool> getData_professors() async {
    String url_professor = "https://muctr-service-production.up.railway.app/api/professor?facultyId=${widget.id_caf}";
    final Uri uri = Uri.parse(url_professor);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postProfessorFromJson(response.body);

      list_professor = result.professors;

      setState(() {
        isLoaded_professor = true;
      });
      return true;
    }else{
      return false;
    }
  }


  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    getData_professors();
    list_selected_professor = [];
    for(var i = 0; i <list_professor.length; i++){
      if(list_professor[i].departmentId == widget.id_dep){
        list_selected_professor.add(i);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.titles),
      ),
      body: Visibility(
        visible: isLoaded_professor,
        replacement: const Center(child:  CircularProgressIndicator(),),
        child: ListView.builder(
          physics: BouncingScrollPhysics(),
          itemCount: list_selected_professor.length,
          /*list_professor[list_selected_professor[index]].surname,*/
            /*list_professor[list_selected_professor[index]].mediaUrl*/
          itemBuilder: (_, index) => Card(
            color: Colors.grey,
            child: Column(
              children: [
                ListTile(
                  title: Text(list_professor[list_selected_professor[index]].surname + " " +
                      list_professor[list_selected_professor[index]].firstName + " " +
                      list_professor[list_selected_professor[index]].secondName,
                      overflow: TextOverflow.ellipsis ),
                  subtitle: Row(children: [Text(list_professor[list_selected_professor[index]].position)]),
                ),
                Container(
                    height: 200.0,
                    child: Image.network(
                        list_professor[list_selected_professor[index]].mediaUrl,
                        errorBuilder: (context, error, stackTrace) {
                          return Image.asset(
                              'no_profile_picture_photo.jpg',
                              width: 150,
                              height: 200,
                              fit: BoxFit.contain
                          );
                        }
                    )
                ),
                Container(
                    padding: EdgeInsets.all(16.0),
                    alignment: Alignment.centerLeft,
                    child: Column(
                      children: [
                        Text("Телефон: "+ list_professor[list_selected_professor[index]].phoneNumber),
                        Text("E-mail: "+ list_professor[list_selected_professor[index]].email),
                      ],
                    )
                ),
              ],
            )
          )
        ),
      ),
    );
  }
}

