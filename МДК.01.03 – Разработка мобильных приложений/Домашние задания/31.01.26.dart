import 'package:flutter/material.dart';

void main(){
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        backgroundColor: Colors.teal[50],
        appBar: AppBar(
          backgroundColor: Colors.teal,
          title: const Text('Визитка'),
        ),
        body: Padding(
          padding: const EdgeInsets.only(top: 40),
          child: Container(
            margin: const EdgeInsets.all(20),
            padding: const EdgeInsets.all(25),
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(15),
            ),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: const [
                    Text(
                      'Категория: Премиум визитка',
                      style: TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w600,
                        color: Colors.black87,
                      ),
                    ),
                    Icon(
                      Icons.workspace_premium,
                      color: Colors.amber,
                      size: 26,
                    ),
                  ],
                ),

                const SizedBox(height: 15),

                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const Text(
                      'Работник',
                      style: TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                        color: Colors.teal,
                      ),
                    ),
                    Icon(Icons.star, color: Colors.amber[700]),
                  ],
                ),

                const SizedBox(height: 20),

                const CircleAvatar(
                  radius: 50,
                  backgroundColor: Colors.teal,
                  child: Icon(Icons.person, size: 60, color: Colors.white),
                ),

                const SizedBox(height: 15),

                const Text(
                  'Олег Петров',
                  style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                ),
                const Text(
                  'Программист-бекендер',
                  style: TextStyle(fontSize: 16, color: Colors.grey),
                ),

                const SizedBox(height: 25),

                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: const [
                    Icon(Icons.star, color: Colors.amber, size: 18),
                    Icon(Icons.star, color: Colors.amber, size: 18),
                    Icon(Icons.star, color: Colors.amber, size: 18),
                    Icon(Icons.star, color: Colors.amber, size: 18),
                    Icon(Icons.star_half, color: Colors.amber, size: 18),
                    SizedBox(width: 10),
                    Text('4.8', style: TextStyle(fontWeight: FontWeight.bold)),
                  ],
                ),

                const SizedBox(height: 20),

                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: const [
                    Icon(Icons.phone, color: Colors.green),
                    Icon(Icons.email, color: Colors.blue),
                    Icon(Icons.school, color: Colors.orange),
                  ],
                ),

                const SizedBox(height: 25),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: () {},
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.teal,
                    ),
                    child: const Text('Написать сообщение'),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
