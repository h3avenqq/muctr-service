import 'package:flutter/material.dart';
import 'package:flutter_html/flutter_html.dart';
import 'package:flutter_html/style.dart';
import 'package:html/dom.dart' as dom;
import 'package:mob_app/models/postStudents.dart';
import 'package:mob_app/views/students_view.dart';
import 'package:url_launcher/url_launcher.dart';




class CardOfStInfo extends StatelessWidget {
  final StudentsInfo element;
  const CardOfStInfo(this.element);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(element.name),
        ),
        body: Visibility(
          visible: isLoaded_st_info,
          replacement: const Center(child:  CircularProgressIndicator(),),
          child: ListView(
            physics: BouncingScrollPhysics(),
            children: [
              Html(
                data: element.description,
                onLinkTap: (String? url, RenderContext context, Map<String, String> attributes, dom.Element? element) async {
                  if (await canLaunchUrl(Uri.parse(url.toString())))
                    await launchUrl(Uri.parse(url.toString()));
                  else
                    // can't launch url, there is some error
                    throw "Could not launch $url";
                },
                // Styling with CSS (not real CSS)
                style: {
                  'h1': Style(color: Colors.red),
                  'p': Style(color: Colors.black87, fontSize: FontSize.medium),
                  'ul': Style(margin: const EdgeInsets.symmetric(vertical: 20))
                },
              ),
            ],
          ),
        )
    );
  }
}
