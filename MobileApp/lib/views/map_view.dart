import 'package:flutter/material.dart';
import 'package:flutter_swiper/flutter_swiper.dart';
import '../data.dart';
import 'package:photo_view/photo_view.dart';

class MapPage extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[350],
      appBar : AppBar(
        title: Text("Карты корпусов"),
        centerTitle: true,
      ),
      body: ListView(
        children: [
          Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Container(
                  child: Text("Миусы:", style: TextStyle(
                      color: Colors.blue[800],
                      fontWeight: FontWeight.bold,
                      fontSize: 35),
                  ),
                ),

                Container(
                  margin: EdgeInsets.symmetric(vertical: 12),
                  height: 300,
                  child: Swiper(
                    itemCount: imgmius.length,
                    itemBuilder: (BuildContext context, int index) {
                      return Column(
                        children: [
                          InkWell(
                            child: Container(
                              child: ClipRRect(
                                  borderRadius: BorderRadius.circular(10),
                                  child: Image(
                                    image: AssetImage(imgmius[index]),
                                    fit: BoxFit.cover,
                                  )),
                            ),
                            onTap: () {
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(builder: (context) => CardOfMap("Миусы", imgmius[index])));
                            },
                          ),

                        ],
                      );
                    },
                    viewportFraction: 0.8,
                    scale: 0.9,
                    pagination: SwiperPagination(),
                  ),
                ),

                Container(
                  child: Text("Тушино:", style: TextStyle(
                      color: Colors.blue[800],
                      fontWeight: FontWeight.bold,
                      fontSize: 35),
                  ),
                ),

                Container(
                  margin: EdgeInsets.symmetric(vertical: 12),
                  height: 400,
                  child: Swiper(
                    itemCount: imgtushino.length,
                    itemBuilder: (BuildContext context, int index) {
                      return Column(
                        children: [
                          InkWell(
                              child: Container(
                                child: ClipRRect(
                                    borderRadius: BorderRadius.circular(10),
                                    child: Image(
                                      image: AssetImage(imgtushino[index]),
                                      fit: BoxFit.cover,
                                    )),
                              ),
                            onTap: () {
                              Navigator.push(
                                  context,
                                  MaterialPageRoute(builder: (context) => CardOfMap("Тушино", imgtushino[index])));
                            },
                          ),

                        ],
                      );
                    },
                    viewportFraction: 0.8,
                    scale: 0.9,
                    pagination: SwiperPagination(),
                  ),
                ),
              ]
          ),
        ],
      ),
    );
  }
}


class CardOfMap extends StatelessWidget {
  final String titles ;
  final String link_of_map;
  const CardOfMap(this.titles, this.link_of_map);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(titles),
        ),
        body: PhotoView(
        imageProvider: AssetImage(link_of_map),
    )
    );
  }
}