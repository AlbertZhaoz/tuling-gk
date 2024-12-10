import 'dart:math';

import 'package:flutter/material.dart';

class GuessPage extends StatefulWidget {
  const GuessPage({super.key, required this.title});
  final String title;

  @override
  State<GuessPage> createState() => _GuessPageState();
}

class _GuessPageState extends State<GuessPage> {
  int _counter = 0;
  var _random = Random();

  void _generateRandomValue() {
    setState(() {
      _counter = _random.nextInt(100);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        // 左侧
        leading: Icon(Icons.menu, color: Colors.black),
        // 右侧列表
        actions: [ IconButton(
            splashRadius: 20,
            onPressed: (){},
            icon: Icon(Icons.run_circle_outlined, color: Colors.blue,)
        )],
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        // 中间布局
        title: TextField(
          keyboardType: TextInputType.number, //键盘类型: 数字
          textAlign: TextAlign.center,
          decoration: InputDecoration( //装饰
              filled: true, //填充
              fillColor: Color(0xffF3F6F9), //填充颜色
              constraints: BoxConstraints(maxHeight: 35), //约束信息
              border: UnderlineInputBorder( //边线信息
                borderSide: BorderSide.none,
                borderRadius: BorderRadius.all(Radius.circular(6)),
              ),
              hintText: "输入 0~99 数字", //提示字
              hintStyle: TextStyle(fontSize: 15), //提示字样式
          ),
        ),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            const Text(
              '[TulingTech] You have pushed the button this many times:',
            ),
            Text(
              '$_counter',
              style: Theme.of(context).textTheme.headlineMedium,
            ),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _generateRandomValue,
        tooltip: 'Increment',
        child: const Icon(Icons.add),
      ), // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}
