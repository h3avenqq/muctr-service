// To parse this JSON data, do
//
//     final post = postFromJson(jsonString);

import 'dart:convert';

Post_News postFromJson(String str) => Post_News.fromJson(json.decode(str));

String postToJson(Post_News data) => json.encode(data.toJson());

class Post_News {
  Post_News({
    required this.news,
  });

  List<News> news;

  factory Post_News.fromJson(Map<String, dynamic> json) => Post_News(
    news: List<News>.from(json["news"].map((x) => News.fromJson(x))),
  );

  Map<String, dynamic> toJson() => {
    "news": List<dynamic>.from(news.map((x) => x.toJson())),
  };
}

class News {
  News({
    required this.id,
    required this.title,
    required this.description,
    required this.publicationDate,
    required this.mediaUrl,
  });

  String id;
  String title;
  String description;
  DateTime publicationDate;
  String mediaUrl;

  factory News.fromJson(Map<String, dynamic> json) => News(
    id: json["id"],
    title: json["title"],
    description: json["description"],
    publicationDate: DateTime.parse(json["publicationDate"]),
    mediaUrl: json["mediaUrl"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "title": title,
    "description": description,
    "publicationDate": publicationDate.toIso8601String(),
    "mediaUrl": mediaUrl,
  };
}
