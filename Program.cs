using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

//https://qiita.com/menon/items/c05fb712126be398f925

namespace ConsoleApp1
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        // どれくらい拾えるのかを簡単なコードでテストしてみる
        string output = "debug.txt";

        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(3000);

            // ①アクティブウィンドウがファイルを開いている場合（ExcelやVisualStudio、OneNoteはどうなるか）

            string[] projectCode = { "0000A000", "1234B567" };//キーワードと物件のリストにする

            IntPtr activeWindowHandle = GetForegroundWindow();

            foreach (var filePath in ProcessUtils.EnumFilesOpened(activeWindowHandle))
            {
                Debug.Write(filePath);

                // パスに0000A000またはA000を含む、または単にキーワードリストにする
                
                // もし複数のファイルがあればどうするか？

                // もし該当するものがないときは？
            }

            // ②アクティブウィンドウをOCRしたとき




            // ④電話＞携帯から通話履歴をDLできるか？
            // ⑤打合せ（オンライン）
            // ⑥オフライン作業
            // ⑦Teams

            // 実行中のすべてのプロセスを取得
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    // プロセス名とIDを表示
                    Console.WriteLine($"プロセス名: {process.ProcessName} (ID: {process.Id})");

                    // メインモジュールのファイル名を表示
                    Console.WriteLine($"ファイル名: {process.MainModule.FileName}");

                    // 他の情報も必要な場合はここに追加してください

                    foreach (var fn in ProcessUtils.EnumFilesOpened(process.Handle))
                    {
                        Console.WriteLine(fn);
                    }


                    Console.WriteLine(); // 空行を挿入
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"エラー: {ex.Message}");
                }
            }

        }
    }
}
