// To parse this JSON data, do
//
//     final postDeportament = postDeportamentFromJson(jsonString);

import 'dart:convert';

PostDeportament postDeportamentFromJson(String str) => PostDeportament.fromJson(json.decode(str));

String postDeportamentToJson(PostDeportament data) => json.encode(data.toJson());

class PostDeportament {
  PostDeportament({
    required this.departments,
  });

  List<Department> departments;

  factory PostDeportament.fromJson(Map<String, dynamic> json) => PostDeportament(
    departments: List<Department>.from(json["departments"].map((x) => Department.fromJson(x))),
  );

  Map<String, dynamic> toJson() => {
    "departments": List<dynamic>.from(departments.map((x) => x.toJson())),
  };
}

class Department {
  Department({
    required this.id,
    required this.name,
  });

  String id;
  String name;

  factory Department.fromJson(Map<String, dynamic> json) => Department(
    id: json["id"],
    name: json["name"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "name": name,
  };
}
