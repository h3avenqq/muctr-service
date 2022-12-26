import 'package:flutter/material.dart';
import 'package:accordion/accordion.dart';
import 'package:accordion/controllers.dart';
import 'package:flutter_html/flutter_html.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:mob_app/models/postSchedule.dart';
import 'package:html/dom.dart' as dom;

class schedule extends StatelessWidget {
  const schedule({Key? key}) : super(key: key);

  final _headerStyle = const TextStyle(
      color: Color(0xffffffff), fontSize: 15, fontWeight: FontWeight.bold);
  final _contentStyleHeader = const TextStyle(
      color: Color(0xff999999), fontSize: 14, fontWeight: FontWeight.w700);
  final _contentStyle = const TextStyle(
      color: Color(0xff999999), fontSize: 14, fontWeight: FontWeight.normal);
  final _loremIpsum =
  '''Lorem ipsum is typically a corrupted version of 'De finibus bonorum et malorum', a 1st century BC text by the Roman statesman and philosopher Cicero, with words altered, added, and removed to make it nonsensical and improper Latin.''';







  @override
  build(context) => Scaffold(
    backgroundColor: Colors.blueGrey[100],
    appBar: AppBar(
      title: Text("Расписание"),centerTitle: true,
    ),
        body: Accordion(
          maxOpenSections: 1,
          headerBackgroundColorOpened: Colors.black54,
          scaleWhenAnimating: true,
          openAndCloseAnimation: true,
          headerPadding:
          const EdgeInsets.symmetric(vertical: 7, horizontal: 15),
          sectionOpeningHapticFeedback: SectionHapticFeedback.heavy,
          sectionClosingHapticFeedback: SectionHapticFeedback.light,
          children: [
            AccordionSection(
              isOpen: false,
              headerBackgroundColorOpened: Colors. blueGrey,
              header: Text("Бакалавриат/специалитет", style: _headerStyle),
              content: Column(
                children: [
                  Html(
                    data: st_schedule[0],
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
            ),
            AccordionSection(
              isOpen: false,
              headerBackgroundColorOpened: Colors. blueGrey,
              header: Text("Магистратура", style: _headerStyle),
              content: Column(
                children: [
                  Html(
                    data: st_schedule[1],
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
            ),
            AccordionSection(
              isOpen: false,
              headerBackgroundColorOpened: Colors. blueGrey,
              header: Text("Аспирантура", style: _headerStyle),
              content: Column(
                children: [
                  Html(
                    data: st_schedule[2],
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
            ),
            AccordionSection(
              isOpen: false,
              headerBackgroundColorOpened: Colors. blueGrey,
              header: Text("Отделение очно-заочного и заочного обучения", style: _headerStyle),
              content: Column(
                children: [
                  Html(
                    data: st_schedule[3],
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
            ),
            AccordionSection(
              isOpen: false,
              headerBackgroundColorOpened: Colors. blueGrey,
              header: Text("Среднее профессиональное образование", style: _headerStyle),
              content: Column(
                children: [
                  Html(
                    data: st_schedule[4],
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
            ),
          ],
        ),
    );
  }