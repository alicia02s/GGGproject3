using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text this NPC says and the time it takes to say it.")]
    private TextInfo[] m_TextFields;

    [SerializeField]
    [Tooltip("Text prefab")]
    private GameObject m_TextPrefab;

    [SerializeField]
    [Tooltip("How long to wait between letters")]
    private float waitTime;

    [SerializeField]
    [Tooltip("If false, then text will display without trigger on first pass")]
    private bool needTrigger;

    private bool canTalk;

    void Awake()
    {
        canTalk = true;
        if (!needTrigger)
        {
            StartCoroutine(Talk());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && canTalk)
        {
            StartCoroutine(Talk());
        }
    }

    private IEnumerator Talk()
    {
        canTalk = false;
        for (int i = 0; i < m_TextFields.Length; i++)
        {
            // spawn blank floating text
            TextInfo info = m_TextFields[i];
            GameObject floatingText = Instantiate(m_TextPrefab, new Vector2(transform.position.x, transform.position.y + 3), transform.rotation);
            floatingText.GetComponent<TMPro.TextMeshPro>().text = "";

            // type out each character
            foreach (char c in info.Text)
            {
                yield return new WaitForSeconds(waitTime);
                floatingText.GetComponent<TMPro.TextMeshPro>().text += c;
            }

            // destory text
            yield return new WaitForSeconds(info.TextTime);
            Destroy(floatingText);
        }
        canTalk = true;
    }
}

[System.Serializable]
public class TextInfo
{
    [SerializeField]
    [Tooltip("The enemy prefab to spawn. This is what will be instantiated each time.")]
    private string m_Text;

    [SerializeField]
    [Tooltip("The time we should wait before the first enemy is spawned.")]
    private float m_TextTime;

    public string Text
    {
        get { return m_Text; }
    }

    public float TextTime
    {
        get { return m_TextTime; }
    }

}