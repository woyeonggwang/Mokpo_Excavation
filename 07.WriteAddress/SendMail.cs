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
    public Button back;     //�ڵ��ư���
    public Button home;     //Ȩ����
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
        /*��ư*/
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
        //deed ĸ�ĵ���
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

        //���� ������
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(""); //���� �����ּ�
        mail.To.Add(add + "@" + dom); //���� ���� �ּ�
        mail.Subject = "���� ������ �߱� ����"; //���� ����
        mail.Body = "";

        // ÷������ - ��뷮�� �ȵ�.
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(name); //÷������ ���, �̸�
        mail.Attachments.Add(attachment);
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");   //smtp ���� ����
        smtpServer.Port = 587;    //������Ʈ
        smtpServer.Credentials = new System.Net.NetworkCredential("mail ID", "mail PW") as ICredentialsByHost; // �����»�� �ּ� �� ��й�ȣ Ȯ��
        smtpServer.EnableSsl = true;  //SmtpCilent���� ssl�� ����Ͽ� ������ ��ȣȭ ���� ���θ� ����
        ServicePointManager.ServerCertificateValidationCallback =                                           //������������ ��ȿ���� �˻��� �ݹ��� �������ų� ����
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
                print("�̸����� �߸��Է��ϼ̽��ϴ�.");
            }
        }
        finally
        {

            SceneManager.LoadScene(8);
        }
        
    }



}
