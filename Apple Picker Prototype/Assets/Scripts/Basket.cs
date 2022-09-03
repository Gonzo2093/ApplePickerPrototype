using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
    {
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        // Установить начальное число очков равным 0
        scoreGT.text = "0";
    }
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координаты Z камеры определяет, как далеко в трехмерном пространстве
        // находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // Преобразовать точку на двумерной плоскости экрана в трехмерные
        // координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси Х в координату Х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        // Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
            Destroy (collidedWith);

        // Преобразовать текст в scoreGT в целое число
        int score = int.Parse(scoreGT.text);
        score += 1;

        // Преобразовать число очков обратно в строку и вывести на экран
        scoreGT.text = score.ToString();

        // Запомнить высшее достижение
        if (score > HighScore.score)
            HighScore.score = score;
    }
}
