import 'package:flutter/material.dart';
import 'package:flutter_swiper/flutter_swiper.dart';
import 'package:mob_app/models/postEvents.dart';
import 'package:mob_app/models/postNews.dart';
import 'package:http/http.dart' as http;
import 'package:flutter_html/flutter_html.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:html/dom.dart' as dom;
import 'package:intl/intl.dart';
import 'dart:math';


List<News> list_news = [];
var isLoaded_news = false;

List<Events> list_events = [];
var isLoaded_events = false;

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {



  Future<bool> getData_news() async {
    String url_news = "https://muctr-service-production.up.railway.app/api/news?limit=10";
    final Uri uri = Uri.parse(url_news);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postFromJson(response.body);

      list_news = result.news;

      setState(() {
        isLoaded_news = true;
      });
      return true;
    }else{
      return false;
    }
  }

  Future<bool> getData_events() async {
    String url_events = "https://muctr-service-production.up.railway.app/api/event?limit=10&unfinished=false";
    final Uri uri = Uri.parse(url_events);

    final response = await http.get(uri);

    if(response.statusCode == 200){
      final result = postEventsFromJson(response.body);

      list_events = result.events;

      setState(() {
        isLoaded_events = true;
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
    getData_news();
    getData_events();

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[350],
      appBar : AppBar(
        title: Text("Новости и события"),
        centerTitle: true,
      ),
      body: Visibility(
        visible: isLoaded_news && isLoaded_events,
        replacement: const Center(child:  CircularProgressIndicator(),),
        child: SingleChildScrollView(
          child: Column(
              children: [
                Container(
                  margin: EdgeInsets.symmetric(vertical: 12),
                  height: 400,
                  child: Swiper(
                    autoplay: true,
                    autoplayDelay: 7000,
                    curve: Curves.easeIn,
                    itemCount: 4,
                    itemBuilder: (BuildContext context, int index) {
                      return Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          InkWell(
                            child: Container(
                              height: 300,
                              child: ClipRRect(
                                  borderRadius: BorderRadius.only(
                                      topLeft: Radius.circular(10),
                                      topRight: Radius.circular(10)),
                                  child: Hero(
                                    tag: list_news[index].mediaUrl,
                                    child: Image(
                                      image: NetworkImage(list_news[index].mediaUrl),
                                      fit: BoxFit.cover,
                                    ),
                                  )),
                            ),
                            onTap: () {
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(builder: (context) => CardOfNews("Новость", list_news[index])));
                            },
                          ),
                          InkWell(
                            child: Container(
                              height: 60,
                              width: MediaQuery.of(context).size.width,
                              decoration: BoxDecoration(
                                  borderRadius: BorderRadius.only(
                                      bottomLeft: Radius.circular(10),
                                      bottomRight: Radius.circular(10)),
                                  color: Colors.white),
                              child: Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Expanded(child: Text(list_news[index].title,
                                        style: TextStyle(
                                            color: Colors.black,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 12)),),
                                    SizedBox(
                                      height: 5,
                                    ),
                                    Text(DateFormat('dd.MM.yyyy').format(list_news[index].publicationDate),
                                        style: TextStyle(
                                            color: Colors.black, fontSize: 10)),
                                  ],
                                ),
                              ),
                            ),
                            onTap: () {
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(builder: (context) => CardOfNews("Новость", list_news[index])));
                            },
                          ),
                          ],
                        );
                    },
                    viewportFraction: 0.8,
                    scale: 0.9,
                  ),
                ),


                /**
                 *
                 *
                 *
                 *
                 * Новости
                 *
                 *
                 *
                 *
                 **/


                Container(
                  child: Text("Новости:", style: TextStyle(
                      color: Colors.blue[800],
                      fontWeight: FontWeight.bold,
                      fontSize: 35),
                  ),
                ),

                Container(
                  child: Card(
                    elevation: 10,
                    child: InkWell(
                      splashColor: Colors.blue.withAlpha(30),
                      onTap: (){
                        Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CardOfNews("Новость", list_news[list_news.length -1 -0])));
                      },
                      child: Column(
                        children: [

                          Text(list_news[list_news.length -1 -0].title, style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold), textAlign: TextAlign.center,),
                          SizedBox(
                            width: double.infinity,
                            height: 100,child:
                          Html(
                            shrinkWrap: true,
                            data: list_news[list_news.length -1 -0].description.substring(0, min(list_news[list_news.length -1 -0].description.length,200)) + "...",
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
                            /*Text( list_news[0].description, style: TextStyle(fontSize: 18),),*/
                          ),

                          Row(children: [Text("  " + DateFormat('dd.MM.yyyy').format(list_news[list_news.length -1 -0].publicationDate,))])
                        ],
                      ),
                  ),
                  )
                ),

                Container(
                    child: Card(
                      elevation: 10,
                      child: InkWell(
                        splashColor: Colors.blue.withAlpha(30),
                        onTap: (){
                          Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CardOfNews("Новость", list_news[list_news.length -1 -1])));
                        },
                        child: Column(
                          children: [

                            Text(list_news[list_news.length -1 -1].title, style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold), textAlign: TextAlign.center,),
                            SizedBox(
                              width: double.infinity,
                              height: 100,child:
                            Html(
                              shrinkWrap: true,
                              data: list_news[list_news.length -1 -1].description.substring(0, min(list_news[list_news.length -1 -1].description.length,200)) + "...",
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
                              /*Text( list_news[0].description, style: TextStyle(fontSize: 18),),*/
                            ),

                            Row(children: [Text("  " + DateFormat('dd.MM.yyyy').format(list_news[list_news.length -1 -1].publicationDate,))])
                          ],
                        ),
                      ),
                    )
                ),
                Container(
                    child: Card(
                      elevation: 10,
                      child: InkWell(
                        splashColor: Colors.blue.withAlpha(30),
                        onTap: (){
                          Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CardOfNews("Новость", list_news[list_news.length -1 -2])));
                        },
                        child: Column(
                          children: [

                            Text(list_news[list_news.length -1 -2].title, style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold), textAlign: TextAlign.center,),
                            SizedBox(
                              width: double.infinity,
                              height: 100,child:
                            Html(
                              shrinkWrap: true,
                              data: list_news[list_news.length -1 -2].description.substring(0, min(list_news[list_news.length -1 -2].description.length,200)) + "...",
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
                              /*Text( list_news[0].description, style: TextStyle(fontSize: 18),),*/
                            ),

                            Row(children: [Text("  " + DateFormat('dd.MM.yyyy').format(list_news[list_news.length -1 -2].publicationDate,))])
                          ],
                        ),
                      ),
                    )
                ),

                Container(
                  child: Card(
                    elevation: 10,
                    child: InkWell(
                      splashColor: Colors.blue.withAlpha(30),
                      onTap: () {
                        Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => CreateNewsCard()));
                      },
                      child: const SizedBox(
                        width: 100,
                        height: 30,
                        child: Center(child: Text("Все новости", style: TextStyle(color: Colors.blueAccent),)),
                      ),
                    ),
                  ),
                ),


                SizedBox(height: 45, width: 300,),



                /**
                 *
                 *
                 *
                 *
                 * События
                 *
                 *
                 *
                 *
                 **/




                Container(
                  child: Text("События:", style: TextStyle(
                      color: Colors.blue[800],
                      fontWeight: FontWeight.bold,
                      fontSize: 35),
                  ),
                ),

                Container(
                    child: Card(
                      elevation: 10,
                      child: InkWell(
                        splashColor: Colors.blue.withAlpha(30),
                        onTap: (){
                          Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CardOfEvent("Событие", list_events[list_events.length -1 -0])));
                        },
                        child: Column(
                          children: [

                            Text(list_events[list_events.length -1 -0].title, style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold), textAlign: TextAlign.center,),
                            SizedBox(
                              width: double.infinity,
                              height: 100,child:
                            Html(
                              shrinkWrap: true,
                              data: list_events[list_events.length -1 -0].description.substring(0, min(list_events[list_events.length -1 -0].description.length,200)) + "...",
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
                              /*Text( list_news[0].description, style: TextStyle(fontSize: 18),),*/
                            ),

                            Row(children: [Text("  " + DateFormat('dd.MM.yyyy').format(list_events[list_events.length -1 -0].startTime,)
                                + " - " + DateFormat('dd.MM.yyyy').format(list_events[list_events.length -1 -0].endTime,)
                            )])
                          ],
                        ),
                      ),
                    )
                ),

                Container(
                    child: Card(
                      elevation: 10,
                      child: InkWell(
                        splashColor: Colors.blue.withAlpha(30),
                        onTap: (){
                          Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CardOfEvent("Событие", list_events[list_events.length -1 -1])));
                        },
                        child: Column(
                          children: [

                            Text(list_events[list_events.length -1 -1].title, style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold), textAlign: TextAlign.center,),
                            SizedBox(
                              width: double.infinity,
                              height: 100,child:
                            Html(
                              shrinkWrap: true,
                              data: list_events[list_events.length -1 -1].description.substring(0, min(list_events[list_events.length -1 -1].description.length,200)) + "...",
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
                              /*Text( list_news[0].description, style: TextStyle(fontSize: 18),),*/
                            ),

                            Row(children: [Text("  " + DateFormat('dd.MM.yyyy').format(list_events[list_events.length -1 -1].startTime,)
                                + " - " + DateFormat('dd.MM.yyyy').format(list_events[list_events.length -1 -1].endTime,)
                            )])
                          ],
                        ),
                      ),
                    )
                ),
                Container(
                    child: Card(
                      elevation: 10,
                      child: InkWell(
                        splashColor: Colors.blue.withAlpha(30),
                        onTap: (){
                          Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CardOfEvent("Событие", list_events[list_events.length -1 -2])));
                        },
                        child: Column(
                          children: [

                            Text(list_events[list_events.length -1 -2].title, style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold), textAlign: TextAlign.center,),
                            SizedBox(
                              width: double.infinity,
                              height: 100,child:
                            Html(
                              shrinkWrap: true,
                              data: list_events[list_events.length -1 -2].description.substring(0, min(list_events[list_events.length -1 -2].description.length,200)) + "...",
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
                              /*Text( list_news[0].description, style: TextStyle(fontSize: 18),),*/
                            ),

                            Row(children: [Text("  " + DateFormat('dd.MM.yyyy').format(list_events[list_events.length -1 -2].startTime,)
                                + " - " + DateFormat('dd.MM.yyyy').format(list_events[list_events.length -1 -2].endTime,)
                            )])
                          ],
                        ),
                      ),
                    )
                ),


                Container(
                  child: Card(
                    elevation: 10,
                    child: InkWell(
                      splashColor: Colors.blue.withAlpha(30),
                      onTap: () {
                        Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => CreateEventsCard()));
                      },
                      child: const SizedBox(
                        width: 100,
                        height: 30,
                        child: Center(child: Text("Все события", style: TextStyle(color: Colors.blueAccent),)),
                      ),
                    ),
                  ),
                ),
              ]
          ),
        ),
      ),
    );
  }
}


class CreateNewsCard extends StatefulWidget {
  const CreateNewsCard({super.key});
  @override
  _CreateNewsCardState createState() => _CreateNewsCardState();
}

class _CreateNewsCardState extends State<CreateNewsCard>{


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Новости"),
      ),
      body: Visibility(
        visible: isLoaded_news,
        replacement: const Center(child:  CircularProgressIndicator(),),
        child: ListView.builder(
          physics: BouncingScrollPhysics(),
          itemCount: list_news.length,
          itemBuilder: (context, index) => Card(
              elevation: 4.0,
              child: InkWell(
                  splashColor: Colors.blue.withAlpha(30),
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => CardOfNews("Новость", list_news[index])));
                  },
                  child: Column(
                    children: [
                      ListTile(
                        subtitle: Text(list_news[index].publicationDate.toString()),
                        title: Text(list_news[index].title.toString(),
                            overflow: TextOverflow.ellipsis ),
                      ),
                      Container(
                        height: 200.0,
                        child: Ink.image(
                          image: NetworkImage(list_news[index].mediaUrl),
                          fit: BoxFit.cover,
                        ),
                      ),
                      Container(
                        padding: EdgeInsets.all(16.0),
                        alignment: Alignment.centerLeft,
                        child: Html(
                          data: list_news[index].description.substring(0, min(list_news[index].description.length,150)) + "...",
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
                      ),
                    ],
                  )
              )
          ),
        ),
      ),
    );
  }
}

class CardOfNews extends StatelessWidget {
  final String titles ;
  final News element;
  const CardOfNews(this.titles, this.element);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(titles),
        ),
        body: ListView(
          physics: BouncingScrollPhysics(),
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Container(
                  margin: EdgeInsets.all(10),
                  child: Text(element.publicationDate.toString(), style: TextStyle(fontSize: 14, )),
                ),
                Container(
                  child: Text(element.title, style: TextStyle(fontSize: 35, fontWeight: FontWeight.bold, ),textAlign: TextAlign.center),
                ),
                Container(
                  height: 200.0,
                  child: Ink.image(
                    image: NetworkImage(element.mediaUrl),
                    fit: BoxFit.cover,
                  ),
                ),
                SizedBox(width: 10, height: 25,),
                Container(
                  child: Html(
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
                ),
              ],
            )
          ],
        )
    );
  }
}



class CreateEventsCard extends StatefulWidget {
  const CreateEventsCard({super.key});
  @override
  _CreateEventsCardState createState() => _CreateEventsCardState();
}

class _CreateEventsCardState extends State<CreateEventsCard>{


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("События"),
      ),
      body: Visibility(
        visible: isLoaded_news,
        replacement: const Center(child:  CircularProgressIndicator(),),
        child: ListView.builder(
          physics: BouncingScrollPhysics(),
          itemCount: list_events.length,
          itemBuilder: (context, index) => Card(
              elevation: 4.0,
              child: InkWell(
                  splashColor: Colors.blue.withAlpha(30),
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => CardOfEvent("Событие", list_events[index])));
                  },
                  child: Column(
                    children: [
                      ListTile(
                        subtitle: Row(children: [Text(DateFormat('dd.MM.yyyy').format(list_events[index].startTime,)
                            + " - " + DateFormat('dd.MM.yyyy').format(list_events[index].endTime,)
                        )]),
                        title: Text(list_events[index].title.toString(),
                            overflow: TextOverflow.ellipsis ),
                      ),
                      Container(
                        height: 200.0,
                        child: Ink.image(
                          image: NetworkImage(list_events[index].mediaUrl),
                          fit: BoxFit.cover,
                        ),
                      ),
                      Container(
                        padding: EdgeInsets.all(16.0),
                        alignment: Alignment.centerLeft,
                        child: Html(
                          data: list_events[index].description.substring(0, min(list_events[index].description.length,150)) + "...",
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
                      ),
                    ],
                  )
              )
          ),
        ),
      ),
    );
  }
}

class CardOfEvent extends StatelessWidget {
  final String titles ;
  final Events element;
  const CardOfEvent(this.titles, this.element);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(titles),
        ),
        body: ListView(
          physics: BouncingScrollPhysics(),
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Container(
                  margin: EdgeInsets.all(10),
                  child: Row(children: [Text(DateFormat('dd.MM.yyyy').format(element.startTime,)
                      + " - " + DateFormat('dd.MM.yyyy').format(element.endTime,)
                  )]),
                ),
                Container(
                  child: Text(element.title, style: TextStyle(fontSize: 35, fontWeight: FontWeight.bold, ),textAlign: TextAlign.center),
                ),
                Container(
                  height: 200.0,
                  child: Ink.image(
                    image: NetworkImage(element.mediaUrl),
                    fit: BoxFit.cover,
                  ),
                ),
                SizedBox(width: 10, height: 25,),
                Container(
                  child: Html(
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
                ),
              ],
            )
          ],
        )
    );
  }
}

