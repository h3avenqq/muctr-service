import 'package:flutter/material.dart';
import 'package:mob_app/accordion_professors.dart';
import 'package:mob_app/models/postDepartment.dart';
import 'package:mob_app/models/postFaculty.dart';
import '../accordion.dart';
import 'package:http/http.dart' as http;
import 'package:flutter_html/flutter_html.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:html/dom.dart' as dom;
import 'dart:math';
import 'dart:convert';




List<Faculty> list_faculty = [];
var isLoaded_faculty = false;

List<Department> list_departament = [];
var isLoaded_departament = false;





class FacultetPage extends StatefulWidget {
  const FacultetPage({Key? key}) : super(key: key);

  @override
  State<FacultetPage> createState() => _FacultetPageState();
}

class _FacultetPageState extends State<FacultetPage> {
  Future<bool> getData_faculty() async {
    String url_faculty = "https://muctr-service-production.up.railway.app/api/faculty";
    final Uri uri = Uri.parse(url_faculty);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postFacultyFromJson(response.body);

      list_faculty = result.faculties;

      setState(() {
        isLoaded_faculty = true;
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
    getData_faculty();

  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: const Text(
          'Факультеты и кафедры',
        ),
      ),
      body: Visibility(
        visible: isLoaded_faculty,
        replacement: const Center(child:  CircularProgressIndicator(),),
        child: ListView.builder(
          physics: BouncingScrollPhysics(),
          itemCount: list_faculty.length,
          itemBuilder: (_, index) => Accordion(
            title: list_faculty[index].name,
            content: list_faculty[index].description,
            id: list_faculty[index].id,
          ),
        ),
      ),
    );
  }
}


class PageOfDepatament extends StatefulWidget {
  final String titles ;
  final String id ;
  const PageOfDepatament({Key? key, required this.titles, required this.id}) : super(key: key);

  @override
  State<PageOfDepatament> createState() => _PageOfDepatamentState();
}

class _PageOfDepatamentState extends State<PageOfDepatament> {
  Future<bool> getData_Departament() async {
    String url_departament = "https://muctr-service-production.up.railway.app/api/department?facultyId=${widget.id}";
    final Uri uri = Uri.parse(url_departament);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postDeportamentFromJson(response.body);

      list_departament = result.departments;

      setState(() {
        isLoaded_departament = true;
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
    getData_Departament();

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.titles),
      ),
      body: Visibility(
        visible: isLoaded_departament,
        replacement: const Center(child:  CircularProgressIndicator(),),
        child: ListView.builder(
          physics: BouncingScrollPhysics(),
          itemCount: list_departament.length,
          itemBuilder: (_, index) => Padding(
            padding: const EdgeInsets.only(left: 15.0, right: 15.0),
            child: ElevatedButton(
              child: Text(list_departament[index].name),
              onPressed: () {
                isLoaded_professor = false;
                Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => PageOfProfessor(titles: list_departament[index].name,
                      id_dep: list_departament[index].id,
                      id_caf: widget.id,)));
              },
            ),
          ),
          /*AccordionProfessors(
            title: list_departament[index].name,
            dep_id: list_departament[index].id,
            id: widget.id,
          ),*/
        ),
      ),
    );
  }
}



/*
class PageOfProfessors extends StatelessWidget {
  final String titles;
  final String id ;
  const PageOfProfessors(this.titles, this.id);

  Future<bool> getData_Departament() async {
    String url_departament = "https://muctr-service-production.up.railway.app/api/department?facultyId=$id";
    final Uri uri = Uri.parse(url_departament);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postDeportamentFromJson(response.body);

      list_departament = result.departments;

      return true;
    }else{
      return false;
    }
  }
  @override
  Widget build(BuildContext context) {
    getData_Departament();
    return Scaffold(
      appBar: AppBar(
        title: Text(titles),
      ),
      body: ListView.builder(
        physics: BouncingScrollPhysics(),
        itemCount: list_departament.length,
        itemBuilder: (_, index) => AccordionProfessors(
          title: list_faculty[index].name,
          content: list_faculty[index].description,
          id: list_faculty[index].id,
        ),
      ),
    );
  }
}

*/

