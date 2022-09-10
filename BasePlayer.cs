using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_BombGame
{
    internal class BasePlayer
    {
        public int dir = 0;
        public int P_xpos;
        public int P_ypos;
        protected int map_size;
        protected ConsoleColor MyColor;
        protected string shape;

        public int GetP_xpos() { return P_xpos; }
        public int GetP_ypos() { return P_ypos; }

        public virtual void Render()
        {
            Console.SetCursorPosition(P_xpos * 2, P_ypos);
            Console.ForegroundColor =MyColor;
            Console.Write(shape);
            Console.ResetColor();
        }

        public virtual void KeyManager()
        {
            //키보드 입력
            switch (dir) //0. 오른 1. 위 2. 왼 3. 아래 4. 뒤집기
            {
                case 0:
                    P_xpos += 1;
                    if (P_xpos + 1 > map_size) { P_xpos = map_size - 1; }
                    break;
                case 1:
                    --P_ypos;
                    if (P_ypos - 1 <= 0) { P_ypos = 0; }
                    break;
                case 2:
                    P_xpos -= 1;
                    if (P_xpos - 1 <= 0) { P_xpos = 0; }
                    break;
                case 3:
                    ++P_ypos;
                    if (P_ypos + 1 > map_size) { P_ypos = map_size - 1; }
                    break;
                case 4:

                    break;
            }
        }
    }
}
