using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_BombGame
{
    internal class Program
    {

        static void Main(string[] args)
        {
            GameLoop gl;
            gl = new GameLoop();

            gl.Awake();
            gl.Start();
            //Factorial(9);
            while (gl.NeedRefresh)
            {
                gl.Update();                
                gl.Render();
            }
        }
        //Recursion : 재귀함수
        /*static int Factorial(int n)
        {
            if (n == 0 || n == 1) { return 1; }
            return n * Factorial(n - 1);
        }*/
        /*static int Factorial(int n)
        {
            GameLoop gl = new GameLoop();
            Player player = new Player();

            for (int i = 8; i > 0; i--)
            {
                if (n == i) { return i; }
            }
            
            if (n == 0) //공백일때 퍼지기
            {
                if (gl.Map_Pos[gl.y - 1, gl.x] == 0) { gl.Map_Pos[player.P_ypos - 1, player.P_xpos] -= 100; } // 상
                if (gl.Map_Pos[gl.y + 1, gl.x] == 0) { gl.Map_Pos[player.P_ypos + 1, player.P_xpos] -= 100; } // 하
                if (gl.Map_Pos[gl.y, gl.x - 1] == 0) { gl.Map_Pos[player.P_ypos, player.P_xpos - 1] -= 100; } //좌
                if (gl.Map_Pos[gl.y, gl.x + 1] == 0) { gl.Map_Pos[player.P_ypos, player.P_xpos + 1] -= 100; } //우
                if (gl.Map_Pos[gl.y - 1, gl.x - 1] == 0) { gl.Map_Pos[player.P_ypos - 1, player.P_xpos - 1] -= 100; } // 좌상
                if (gl.Map_Pos[gl.y + 1, gl.x - 1] == 0) { gl.Map_Pos[player.P_ypos + 1, player.P_xpos - 1] -= 100; } // 좌하
                if (gl.Map_Pos[gl.y - 1, gl.x + 1] == 0) { gl.Map_Pos[player.P_ypos - 1, player.P_xpos + 1] -= 100; } //우상
                if (gl.Map_Pos[gl.y + 1, gl.x + 1] == 0) { gl.Map_Pos[player.P_ypos + 1, player.P_xpos + 1] -= 100; } //우하
            }
            return n * Factorial(n - 1);
        }*/

    }
}
