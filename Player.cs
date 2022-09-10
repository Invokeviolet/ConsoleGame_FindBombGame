using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_BombGame
{

    internal class Player : BasePlayer
    {

        public void Awake()
        {
            //생성자 초기값 할당

        }
        public void Start()
        {
            // 눈 코 입 
            P_xpos = 0;
            P_ypos = 0;
            map_size = 0;
            MyColor= ConsoleColor.Green;
            shape = "＠";
        }

        public void SetMapSize(int map_size) //입력된 맵 크기를 가져올거야
        {
            this.map_size = map_size;
        }
        public void KeyRight() //0. 오른 1. 위 2. 왼 3. 아래 4. 뒤집기
        {
            dir = 0;
        }
        public void KeyLeft()
        {
            dir = 2;
        }
        public void KeyUp()
        {
            dir = 1;
        }
        public void KeyDown()
        {
            dir = 3;
        }
        public void Spacebar()
        {
            dir = 4;
        }
        public void Update()
        {
            KeyManager();
        }

        public override void Render()
        {
            base.Render();
        }
       
    }
}
