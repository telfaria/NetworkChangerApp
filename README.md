This document was created with the assistance of ChatGPT, a language model developed by OpenAI.

日本語の説明は下のほうにあります

# English

# NetworkChangerApp

NetworkChangerApp is a simple utility application designed to modify network settings, specifically the IP address and related configurations of network adapters.

## How to Use

1. **Select Network Interface**: Choose the desired network interface from the dropdown menu on the left.
2. **Select Profile**: Pick the profile you want to apply from the dropdown menu on the right.
3. **Execute**: Click the "<-" button in the center to execute the process.

Based on the selected profile, the Netsh command will be executed, and the IP address of the specified interface will be changed.

## Sample Profiles

```json
{
    "Profiles": [
        {
            "name": "DHCP",
            "description": "DHCP Setting",
            "ipAddress": "dhcp",
            "netMask": "",
            "gatewayAddress": "",
            "dns": [ "dhcp" ]
        },
        {
            "name": "Profile1",
            "description": "Description1",
            "ipAddress": "192.168.0.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.0.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        },
        {
            "name": "Profile2",
            "description": "Description2",
            "ipAddress": "192.168.1.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.1.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        }
    ]
}
```
These profiles provide examples of both DHCP configuration and static IP configurations for different network scenarios. The profile.json file can be customized with additional profiles as needed.

## Operation
The application executes the Netsh command based on the values defined in the profile. The results of the changes are displayed in the message box at the bottom of the screen.

# 日本語

# NetworkChangerApp

NetworkChangerAppは、ネットワークアダプタのIPアドレスなどのネットワーク設定を変更するためのシンプルなユーティリティアプリケーションです。

## 使用方法

1. **ネットワークインターフェイスの選択**: 左側のドロップダウンメニューから変更したいネットワークインターフェイスを選択します。
2. **プロファイルの選択**: 右側のドロップダウンメニューから適用したいプロファイルを選択します。
3. **実行**: 真ん中の "<-" ボタンをクリックして処理を実行します。

選択したプロファイルに基づいて、Netshコマンドが実行され、指定されたインターフェイスのIPアドレスが変更されます。

## プロファイルの例

```json
{
    "Profiles": [
        {
            "name": "DHCP",
            "description": "DHCP Setting",
            "ipAddress": "dhcp",
            "netMask": "",
            "gatewayAddress": "",
            "dns": [ "dhcp" ]
        },
        {
            "name": "Profile1",
            "description": "Description1",
            "ipAddress": "192.168.0.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.0.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        },
        {
            "name": "Profile2",
            "description": "Description2",
            "ipAddress": "192.168.1.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.1.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        }
    ]
}
```
これらのプロファイルは、DHCP設定と静的IP設定の例を提供しています。profile.jsonファイルを必要に応じて追加のプロファイルでカスタマイズできます。

## 動作
プロファイルで定義された値をもとに、Netshコマンドを実行します。変更の結果は画面下部の出力メッセージボックスに表示されます。

