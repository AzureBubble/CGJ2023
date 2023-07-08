using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource BGMSource;
    public AudioSource FXSource;

    private void Awake()
    {
        // ����Ƿ��Ѿ�����UIHolder��ʵ��������������ٵ�ǰ����
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // ����UIHolder��ʵ���־���
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}