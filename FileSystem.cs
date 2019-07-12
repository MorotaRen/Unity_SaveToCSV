using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//前提
using System.Text;
using System.IO;


using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FileSystem : MonoBehaviour
{
    [SerializeField]
    int m_SaveInt;
    [SerializeField]
    string m_SaveString;
    [SerializeField]
    GameObject m_OutPutText;

    void Start()
    {

    }
    public void FileSave()
    {
        ///<summary>
        ///保存先パス(絶対パス),追記か上書きか,エンコード
        ///</summary>
        StreamWriter sw = new StreamWriter(@"SaveData.csv", false, Encoding.GetEncoding("Shift_JIS"));
        //保存するデータの記入
        sw.WriteLine(m_SaveInt);
        sw.WriteLine(m_SaveString);
        //終わったら閉じる
        sw.Close();
        Debug.Log("セーブ完了" + "(" + m_SaveInt + "," + m_SaveString + ")");
        SceneManager.LoadScene("NextScene");
    }
    public void FileLoad()
    {
        ///<summary>
        ///読み込みファイルパス(絶対パス),エンコード
        ///</summary>
        StreamReader sr = new StreamReader(@"SaveData.csv",Encoding.GetEncoding("Shift_JIS"));
        string line;
        //lineの中身がNULLになるまで回す
        while ((line = sr.ReadLine()) != null)
        {
            //ファイルから読み込んだものをTextに追加
            Debug.Log(line);
            m_OutPutText.GetComponent<Text>().text += line;
        }
        //終わったら閉じる
        sr.Close();
    }
}
