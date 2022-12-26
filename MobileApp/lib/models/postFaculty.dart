// To parse this JSON data, do
//
//     final postFaculty = postFacultyFromJson(jsonString);

import 'dart:convert';

PostFaculty postFacultyFromJson(String str) => PostFaculty.fromJson(json.decode(str));

String postFacultyToJson(PostFaculty data) => json.encode(data.toJson());

class PostFaculty {
  PostFaculty({
    required this.faculties,
  });

  List<Faculty> faculties;

  factory PostFaculty.fromJson(Map<String, dynamic> json) => PostFaculty(
    faculties: List<Faculty>.from(json["faculties"].map((x) => Faculty.fromJson(x))),
  );

  Map<String, dynamic> toJson() => {
    "faculties": List<dynamic>.from(faculties.map((x) => x.toJson())),
  };
}

class Faculty {
  Faculty({
    required this.id,
    required this.name,
    required this.description,
  });

  String id;
  String name;
  String description;

  factory Faculty.fromJson(Map<String, dynamic> json) => Faculty(
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