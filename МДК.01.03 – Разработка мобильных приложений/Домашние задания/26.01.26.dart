import 'package:flutter/material.dart';

void main(){
  runApp(const MyApp());
}


class MyApp extends StatelessWidget{
  const MyApp ({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        backgroundColor: Colors.pink,
        appBar: AppBar(
          backgroundColor: Colors.lightGreenAccent,
          leading: Icon(
            Icons.settings, 
            color: Colors.pink,
            size: 40,
          ),
        ),
        body: const Center(
          child: Text(
            "Власов Владислав Викторович",
            style: TextStyle(
              fontSize: 40,
              color: Colors.lightGreenAccent,
              fontWeight: FontWeight.bold
            ),
          ),
        ),
        ),
      );
  }
}