using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject menuOpcoes;
    public CanvasGroup backgroundGroup;

    public float fadeSpeed = 2f;
    public float slideSpeed = 1500f; // ou testa 1000–1500

    private bool fadingIn = false;
    private bool sliding = false;

    private RectTransform menuRect;
    private Vector2 targetPos;

    void Start()
    {
        backgroundGroup.alpha = 0f;
        backgroundGroup.gameObject.SetActive(true);

        menuRect = menuOpcoes.GetComponent<RectTransform>();

        // guarda posição final
        targetPos = menuRect.anchoredPosition;

        // começa fora da tela (esquerda)
        menuRect.anchoredPosition = new Vector2(-250f, targetPos.y);

        menuOpcoes.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown && !fadingIn)
        {
            fadingIn = true;
        }

        // FADE
        if (fadingIn && backgroundGroup.alpha < 1f)
        {
            backgroundGroup.alpha += fadeSpeed * Time.deltaTime;
        }
        else if (fadingIn && !sliding)
        {
            // terminou fade → ativa menu e começa slide
            menuOpcoes.SetActive(true);
            sliding = true;
        }

        // SLIDE
        if (sliding)
        {
            menuRect.anchoredPosition = Vector2.MoveTowards(
                menuRect.anchoredPosition,
                targetPos,
                slideSpeed * Time.deltaTime
            );
        }
    }
}