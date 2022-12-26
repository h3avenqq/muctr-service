// To parse this JSON data, do
//
//     final postStudents = postStudentsFromJson(jsonString);

import 'dart:convert';

PostStudents postStudentsFromJson(String str) => PostStudents.fromJson(json.decode(str));

String postStudentsToJson(PostStudents data) => json.encode(data.toJson());

class PostStudents {
  PostStudents({
    required this.studentsInfo,
  });

  List<StudentsInfo> studentsInfo;

  factory PostStudents.fromJson(Map<String, dynamic> json) => PostStudents(
    studentsInfo: List<StudentsInfo>.from(json["studentsInfo"].map((x) => StudentsInfo.fromJson(x))),
  );

  Map<String, dynamic> toJson() => {
    "studentsInfo": List<dynamic>.from(studentsInfo.map((x) => x.toJson())),
  };
}

class StudentsInfo {
  StudentsInfo({
    required this.id,
    required this.name,
    required this.description,
  });

  String id;
  String name;
  String description;

  factory StudentsInfo.fromJson(Map<String, dynamic> json) => StudentsInfo(
    id: json["id"],
    name: json["name"],
    description: json["description"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "name": name,
    "description": description,
  };
}
