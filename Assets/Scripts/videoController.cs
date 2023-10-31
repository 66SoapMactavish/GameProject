using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]
//���غ���Զ���VideoPlayer�����ӵ�game object

public class VideoPlay : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;//������Ƶ���������
    [SerializeField] public VideoClip ��ƵԴ;//������Ƶ��Դ
    [SerializeField] private RawImage rawImage;//����ԭʼͼ��
    [SerializeField] public bool isLoop = true;
    /*===ע�⣺ʹ��RawImageʱ����ʹ��ÿ�����ڵ�RawImage����һ������Ļ��Ƶ��ã�������ֻ�������ڱ�������ʱ�ɼ���ͼ��===*/

    //˽�б�����¶���༭��
    [Range(0f, 1f)] public float �����ٶ� = 1f;//�����ٶ�

    private void Awake()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();//��ȡ��Ƶ���������
        rawImage = this.GetComponent<RawImage>();//��ȡԭʼͼ�����
    }

    void Start()
    {
        videoPlayer.clip = ��ƵԴ;//��ƵԴ

        if (this.isLoop == false)
        {
            videoPlayer.loopPointReached += End;
        }
    }

    void Update()
    {
        //ֻ����һ����ȡ��ע��






        //��VideoPlayerd����Ƶ��Ⱦ��UGUI��RawImage
        rawImage.texture = videoPlayer.texture;//RawImage������ʾ�κ�������Image���ֻ����ʾSprite����||videoPlayer.texture:��Ƶ���ݵ��ڲ�����ֻ����
        VideoFade();
    }

    //һ�������Ч�����о���û��ʲô����
    public void VideoFade()
    {
        videoPlayer.Play();//��ʼ����
        rawImage.color = Color.Lerp(rawImage.color, Color.white, �����ٶ� * Time.deltaTime);
        /*
         * Color: RGBA��ɫ��ʾ��ʽ�����ڴ�����ɫ�� ÿ����ɫ��������0��1��Χ�ڵĸ���ֵ������(r,g,b)����RGB��ɫ�ռ��е���ɫ��Alpha����(a)����͸���� ,alphaΪ1��ʾ��ȫ��͸����alphaΪ0��ʾ��ȫ͸��
         * Lerp: �ڲ���1��ɫ�����2��ɫ֮�䰴����3�������Բ�ֵ, ����3������0��1֮�䡣������3Ϊ0ʱ���ز���3��������3Ϊ1ʱ���� /����3/
         * Color.white������ɫ��RGBA Ϊ (1, 1, 1, 1)
         * Time.deltaTime:  �����һ��֡����ǰ֡�ļ��������Ϊ��λ(ֻ��)��OnGUI���ɿ�����Ϊÿ��֡���ܻ��ε�����
         */
    }

    public void End(VideoPlayer thisPlay)
    {
        Debug.Log("end");
        if (videoPlayer.isLooping == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}