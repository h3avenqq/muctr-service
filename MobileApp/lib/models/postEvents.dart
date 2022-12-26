// To parse this JSON data, do
//
//     final postEvents = postEventsFromJson(jsonString);

import 'dart:convert';

PostEvents postEventsFromJson(String str) => PostEvents.fromJson(json.decode(str));

String postEventsToJson(PostEvents data) => json.encode(data.toJson());

class PostEvents {
  PostEvents({
    required this.events,
  });

  List<Events> events;

  factory PostEvents.fromJson(Map<String, dynamic> json) => PostEvents(
    events: List<Events>.from(json["events"].map((x) => Events.fromJson(x))),
  );

  Map<String, dynamic> toJson() => {
    "events": List<dynamic>.from(events.map((x) => x.toJson())),
  };
}

class Events {
  Events({
    required this.id,
    required this.title,
    required this.description,
    required this.publicationDate,
    required this.startTime,
    required this.endTime,
    required this.mediaUrl,
  });

  String id;
  String title;
  String description;
  DateTime publicationDate;
  DateTime startTime;
  DateTime endTime;
  String mediaUrl;

  factory Events.fromJson(Map<String, dynamic> json) => Events(
    id: json["id"],
    title: json["title"],
    description: json["description"],
    publicationDate: DateTime.parse(json["publicationDate"]),
    startTime: DateTime.parse(json["startTime"]),
    endTime: DateTime.parse(json["endTime"]),
    mediaUrl: json["mediaUrl"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "title": title,
    "description": description,
    "publicationDate": publicationDate.toIso8601String(),
    "startTime": startTime.toIso8601String(),
    "endTime": endTime.toIso8601String(),
    "mediaUrl": mediaUrl,
  };
}
