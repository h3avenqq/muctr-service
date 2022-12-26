import 'package:flutter/material.dart';
import 'package:mob_app/custom_icons.dart';
import 'package:mob_app/views/department_view.dart';
import 'package:mob_app/views/home_view.dart';
import 'package:mob_app/views/map_view.dart';
import 'package:mob_app/views/students_view.dart';

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  int currentPageIndex = 0;

  final List<Widget> _children = [
    HomePage(),
    FacultetPage(),
    StudentPage(),
    MapPage(),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      bottomNavigationBar: NavigationBar(
        height: 60,
        onDestinationSelected: (int index) {
          setState(() {
            currentPageIndex = index;
          });
        },
        selectedIndex: currentPageIndex,
        destinations: const <Widget>[
          NavigationDestination(
            icon: Icon(Custom_icons.home),
            selectedIcon: Icon(Custom_icons.home, size: 40,),
            label: 'Главная',
            tooltip: 'Новости\nСобытия',
          ),
          NavigationDestination(
            icon: Icon(Custom_icons.graduation_cap),
            selectedIcon: Icon(Custom_icons.graduation_cap, size: 40,),
            label: 'Кафедры',
            tooltip: 'Список факудьтетов/кафедр,\nсостав',
          ),
          NavigationDestination(
            icon: Icon(Custom_icons.people),
            selectedIcon: Icon(Custom_icons.people, size: 40,),
            label: 'Студентам',
            tooltip: 'Расписание\nМат.поддержка\nЕдиный деканат\nСтутгородок',
          ),
          NavigationDestination(
            icon: Icon(Custom_icons.map),
            selectedIcon: Icon(Custom_icons.map, size: 40,),
            label: 'Карта',
            tooltip: 'Карты корпусов',
          ),
        ],
      ),
      body: _children[currentPageIndex],
    );
  }
}