// To parse this JSON data, do
//
//     final postProfessor = postProfessorFromJson(jsonString);

import 'dart:convert';

PostProfessor postProfessorFromJson(String str) => PostProfessor.fromJson(json.decode(str));

String postProfessorToJson(PostProfessor data) => json.encode(data.toJson());

class PostProfessor {
  PostProfessor({
    required this.professors,
  });

  List<Professor> professors;

  factory PostProfessor.fromJson(Map<String, dynamic> json) => PostProfessor(
    professors: List<Professor>.from(json["professors"].map((x) => Professor.fromJson(x))),
  );

  Map<String, dynamic> toJson() => {
    "professors": List<dynamic>.from(professors.map((x) => x.toJson())),
  };
}

class Professor {
  Professor({
    required this.id,
    required this.surname,
    required this.firstName,
    required this.secondName,
    required this.departmentId,
    required this.position,
    required this.phoneNumber,
    required this.email,
    required this.mediaUrl,
  });

  String id;
  String surname;
  String firstName;
  String secondName;
  String departmentId;
  String position;
  String phoneNumber;
  String email;
  String mediaUrl;

  factory Professor.fromJson(Map<String, dynamic> json) => Professor(
    id: json["id"],
    surname: json["surname"],
    firstName: json["firstName"],
    secondName: json["secondName"],
    departmentId: json["departmentId"],
    position: json["position"],
    phoneNumber: json["phoneNumber"],
    email: json["email"],
    mediaUrl: json["mediaUrl"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "surname": surname,
    "firstName": firstName,
    "secondName": secondName,
    "departmentId": departmentId,
    "position": position,
    "phoneNumber": phoneNumber,
    "email": email,
    "mediaUrl": mediaUrl,
  };
}
