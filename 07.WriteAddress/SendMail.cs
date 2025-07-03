using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class SendMail : MonoBehaviour
{

    [Tooltip("Button")]
    public Button back;     //뒤돌아가기
    public Button home;     //홈으로
    public Button send;

    [Tooltip("email")]
    public Text address;
    public Dropdown domain;
    string add;
    string dom;

    [Tooltip("CaptureDeed")]
    public Camera camera;
    private int resWidth;
    private int resHeight;
    string path;

    private SoundManager sound;

    private void Awake()
    {
        /*버튼*/
        send.onClick.AddListener(() => BtnSend());

    }

    public void Start()
    {
        resWidth = 468;
        resHeight = 664;
        path = Application.persistentDataPath + "/";
        Debug.Log(path);
        sound = GetComponent<SoundManager>();
    }
    public void Update()
    {
        add = address.text;
        dom = domain.options[domain.value].text;
    }
    public void BtnSend()
    {
        sound.Play(0);
        //deed 캡쳐따기
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;
        name = path + "Excabation" + ".png";
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);

        //메일 보내기
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(""); //메일 보낼주소
        mail.To.Add(add + "@" + dom); //메일 받을 주소
        mail.Subject = "목포 세관터 발굴 증서"; //메일 제목
        mail.Body = "";

        // 첨부파일 - 대용량은 안됨.
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(name); //첨부파일 경로, 이름
        mail.Attachments.Add(attachment);
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");   //smtp 서버 지정
        smtpServer.Port = 587;    //구글포트
        smtpServer.Credentials = new System.Net.NetworkCredential("mail ID", "mail PW") as ICredentialsByHost; // 보내는사람 주소 및 비밀번호 확인
        smtpServer.EnableSsl = true;  //SmtpCilent에서 ssl을 사용하여 연결을 암호화 할지 여부를 지정
        ServicePointManager.ServerCertificateValidationCallback =                                           //서버인증서의 유효성을 검사할 콜백을 가져오거나 설정
        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true; 
            };
        try
        {
            smtpServer.Send(mail);
            Debug.Log("success");
        }
        catch(Exception e)
        { 
            if(e.ToString() == "String")
            {
                print("이메일을 잘못입력하셨습니다.");
            }
        }
        finally
        {

            SceneManager.LoadScene(8);
        }
        
    }



}
