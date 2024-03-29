import 'package:flutter/material.dart';
import 'home_widget.dart';

void main() {
  runApp(const MyApp());
  }

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    ErrorWidget.builder = (FlutterErrorDetails details) {
      return Container(
        alignment: Alignment.center,
        child: Center(
          child: CircularProgressIndicator(),
        ),
      );
    };
    return const MaterialApp(
        debugShowCheckedModeBanner: false,
        home: Home()
    );
  }
}



