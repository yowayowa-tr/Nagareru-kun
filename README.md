# Nagareru-kun

## バックエンド
<br>デフォルトでデモ用。実際に使う場合は、

  + Authentication.cs
  + MessageHandler.cs  

のコメント部分をコメントアウトする。また、

+ MainWindow.xaml
+ MainWindow.xaml.cs
+ Authentication.cs
+ MessageHandler.cs  

の中にある

> //for demo
> <br>
> \<!-- for demo -->

直下の行を削除する。

### MainWindowについて
  ##### Authenticationボタン
  アカウント認証。

  ##### TextBox(URL)
  会議中のチャットメッセージのリンクを入力。<br>
  リンクは <i>任意のチャットメッセージ&rarr;その他のオプション&rarr;リンクをコピー</i> で取得可能。

  ##### GetMessageボタン
  最新のチャットメッセージ（前回取得していない分）を取得。<br>
  アカウント認証しないと動作しません。

  ##### TextBox(Message)
  送信するメッセージを入力。

  ##### SetMessageボタン
  TextBoxに入力されたメッセージを送信。<br>
  実際にチャットメッセージが送られます。

  ##### AddMessageボタン（デモ用）
  TextBoxに入力されたメッセージを送信。<br>
  チャットメッセージは送られません。
