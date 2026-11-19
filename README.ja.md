# Openlilavatarutils

[English](README.md)

選択したGameObjectを指定した状態で、lilAvatarUtilsを開くためのUnity Editor用ショートカットです。

## コンセプト

Openlilavatarutilsは、アバター編集時にlilAvatarUtilsへ簡単にアクセスできるようにするために開発されました。

通常、lilAvatarUtilsを個別に開いてから対象のGameObjectを手動で指定する必要がありますが、このツールはGameObjectのコンテキストメニューにショートカットを追加します。

ショートカットを選択すると、lilAvatarUtilsのエディターウィンドウを開き、選択中のGameObjectを対象として自動的に割り当てようとします。

## 概要

- **Unityバージョン：** 2022.3.22f1
- **メニュー：** `GameObject > Open lilAvatarUtils`
- **依存ツール：** lilAvatarUtils

## 機能

- **コンテキストメニューへのショートカット追加** — GameObjectのコンテキストメニューからlilAvatarUtilsを開けます。
- **対象GameObjectの自動割り当て** — 選択中のGameObjectを、開いたウィンドウの対象として自動的に割り当てようとします。
- **アセンブリへの直接参照を回避** — Reflection（リフレクション）を使用してlilAvatarUtilsを検索・操作するため、コンパイル時に直接参照する必要がありません。
- **依存関係の確認** — 対応するlilAvatarUtilsのエディターウィンドウが見つからない場合、警告ダイアログを表示します。

## 動作要件

- Unity 2022.3.22f1
- UnityプロジェクトにlilAvatarUtilsがインストールされていること

## 使い方

1. UnityプロジェクトにlilAvatarUtilsをインストールします。
2. アバタープロジェクトを開きます。
3. Hierarchy上で操作したいGameObjectを選択するか、右クリックします。
4. GameObjectのコンテキストメニューから `Open lilAvatarUtils` を選択します。

lilAvatarUtilsのウィンドウが開き、選択中のGameObjectが対象として自動的に割り当てられます。

## 注意事項

- コンテキストメニューは、シーン内で選択されたGameObjectに対して使用できます。Project内の永続的なアセットは対象外です。
- 対象GameObjectの割り当てにはReflectionを使用し、lilAvatarUtilsのエディターウィンドウ内から適切なフィールドを検索します。
- 互換性はlilAvatarUtilsの内部構造に依存します。ウィンドウの型や対象を保持するフィールドが変更された場合、自動割り当てに影響する可能性があります。

## 作者

- nur_ieren
- vor_ges

## ライセンス

このプロジェクトはMIT Licenseのもとで公開されています。詳細は `LICENSE` ファイルを参照してください。

[MIT License](https://opensource.org/license/mit)
