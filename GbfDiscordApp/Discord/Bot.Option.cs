using System;
using System.Collections.Generic;
using System.Text;

namespace GbfDiscordAppCs.Discord
{
    /// <summary>
    /// DiscordBotクラスのオプションファイルです。<br></br>
    /// 定数の中身を定義しています。<br></br>
    /// トークンの設定は必須。<br></br>
    /// その他については任意で変更してください。<br></br>
    /// </summary>
    partial class Bot
    {
        /// <summary>
        /// コマンドの接頭詞を指定します。<br></br>
        /// 例<br></br>
        /// |  接頭詞  -> 認識するコマンド<br></br>
        /// |   $      -> $command<br></br>
        /// |   /      -> /command<br></br>
        /// </summary>
        const char COMMAND_PREFIX = '$';

        /// <summary>
        /// ボットのトークンを指定します。<br></br>
        /// 公式ドキュメントにもありますが、<br></br>
        /// トークンはくれぐれも流出せぬようご注意ください。<br></br>
        /// 誤ってコミットも無いように。<br></br>
        /// </summary>
        const string BOT_TOKEN = "ここにトークン";
    }
}
