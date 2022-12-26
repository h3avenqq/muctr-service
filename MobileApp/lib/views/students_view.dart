import 'package:flutter/material.dart';
import 'package:mob_app/models/postStudents.dart';
import 'package:http/http.dart' as http;
import 'package:mob_app/views/st_info.dart';
import 'package:mob_app/views/st_schedule.dart';

List<StudentsInfo> list_st_info = [];
var isLoaded_st_info = false;
class StudentPage extends StatefulWidget {
  const StudentPage({Key? key}) : super(key: key);

  @override
  State<StudentPage> createState() => _StudentPageState();
}

class _StudentPageState extends State<StudentPage> {
  Future<bool> getData_st_info() async {
    String url_st_info = "https://muctr-service-production.up.railway.app/api/studentsinfo";
    final Uri uri = Uri.parse(url_st_info);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postStudentsFromJson(response.body);

      list_st_info = result.studentsInfo;

      setState(() {
        isLoaded_st_info = true;
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
    getData_st_info();

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[350],
      appBar : AppBar(
        title: Text("Студентам"),
        centerTitle: true,
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              InkWell(
                child: Container(
                  margin: EdgeInsets.all(15),
                  height: 150,
                  width: 150,
                  padding: const EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(15)),
                    color: Colors.deepPurple[200],
                    boxShadow: <BoxShadow>[
                      BoxShadow(
                          color: Colors.black26,
                          blurRadius: 15.0,
                          offset: Offset(0.0, 0.75)
                      )
                    ],
                  ),
                  child: Center(child: const Text("Студгородок",textAlign: TextAlign.center,style: TextStyle(fontSize: 16, fontWeight: FontWeight.w500))),
                ),
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => CardOfStInfo(list_st_info[2])));
                },
              ),

              InkWell(
                child: Container(
                  margin: EdgeInsets.all(15),
                  height: 150,
                  width: 150,
                  padding: const EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(15)),
                    color: Colors.blue[300],
                    boxShadow: <BoxShadow>[
                      BoxShadow(
                          color: Colors.black26,
                          blurRadius: 15.0,
                          offset: Offset(0.0, 0.75)
                      )
                    ],
                  ),
                  child: Center(child: const Text("Материальная поддержка",textAlign: TextAlign.center,style: TextStyle(fontSize: 16, fontWeight: FontWeight.w500))),
                ),
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => CardOfStInfo(list_st_info[0])));
                },
              ),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              InkWell(
                child: Container(
                  margin: EdgeInsets.all(15),
                  height: 150,
                  width: 150,
                  padding: const EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(15)),
                    color: Colors.lightGreen[300],
                    boxShadow: <BoxShadow>[
                      BoxShadow(
                          color: Colors.black26,
                          blurRadius: 15.0,
                          offset: Offset(0.0, 0.75)
                      )
                    ],
                  ),
                  child: Center(child: const Text("Единый деканат",textAlign: TextAlign.center,style: TextStyle(fontSize: 16, fontWeight: FontWeight.w500))),
                ),
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => CardOfStInfo(list_st_info[1])));
                },
              ),
              InkWell(
                child: Container(
                  margin: EdgeInsets.all(15),
                  height: 150,
                  width: 150,
                  padding: const EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(15)),
                    color: Colors.red[200],
                    boxShadow: <BoxShadow>[
                      BoxShadow(
                          color: Colors.black26,
                          blurRadius: 15.0,
                          offset: Offset(0.0, 0.75)
                      )
                    ],
                  ),
                  child: Center(child: const Text("Расписание",textAlign: TextAlign.center,style: TextStyle(fontSize: 16, fontWeight: FontWeight.w500))),
                ),
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => schedule()));
                },
              ),
            ],
          )

        ],
      ),

    );
  }
}








