import 'package:flutter/material.dart';
import 'package:flutter_html/flutter_html.dart';
import 'package:mob_app/views/department_view.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:html/dom.dart' as dom;

class Accordion extends StatefulWidget {
  final String title;
  final String content;
  final String id;

  const Accordion({Key? key, required this.title, required this.content, required this.id})
      : super(key: key);
  @override
  _AccordionState createState() => _AccordionState();
}

class _AccordionState extends State<Accordion> {
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
            Html(
            data: widget.content,
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
              ElevatedButton(
                child: const Text('Состав факультета/кафедры'),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => PageOfDepatament(titles: widget.title,id: widget.id,)));
                },
              ),
            ],
          )
        )
            : Container()
      ]),
    );
  }
}


