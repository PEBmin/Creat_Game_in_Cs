using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum BLOCKTYPE
{
    BT_None = 0,
    BT_L,
    BT_RevL,
    BT_Sq,
    BT_I,
    BT_T,
    BT_Z,
    BT_S,
    BT_MAX = BT_S
}



class Block
{

    static int[,,] Shapes = new int[7, 4, 2]
{
      { { 0, 0 }, { 0, -2 }, { 0, -1 }, { 1, 0 } }, // BT_L
      { { 0, 0 }, { 0, -2 }, { 0, -1 }, { -1, 0 } }, // BT_RevL
      { { 0, 0 }, { 0, -1 }, { 1, -1 }, { 1, 0 } }, // BT_Sq
      { { 0, 0 }, { 0, -2 }, { 0, -1 }, { 0, 1 } }, // BT_I
      { { 0, 0 }, { -1, 0 }, { 0, -1 }, { 1, 0 } }, //  BT_T
      { { 0, 0 }, { -1, -1 }, { 0, -1 }, { 1, 0 } }, // BT_Z
      { { 0, 0 }, { 1, -1 }, { 0, -1 }, { -1, 0 } }, // BT_S
};

    public class tetris_t
    {
        public List<int[]> ShapeCur = new List<int[]>();

        public tetris_t()
        {
            for (int x = 0; x < 4; ++x)
            {
                // 현재 블럭
                ShapeCur.Add(new int[2]);
            }
        }

        public int[] CenterCur = new int[2];

        public int NowScore;
        public int CurBlock;

    }

    tetris_t tt = null;


    int BlockTypeCount;
    // 스크린을 새로 가져온다. null인 이유는 프로그램에서 만든 스크린 정보를 바로 가져오기 위해서이다.
    TetrisScreen Screen = null;
    //▣□□□
    //▣□□□
    //▣□□□
    //▣□□□
    public Block(TetrisScreen _screen)
    {
        tetris_t _tt = new tetris_t();
        tt = _tt;
        Screen = _screen;
        BlockTypeCount = 7;
    }

    public void TetrisReset()
    {
        SponNewBlock();
    }
    // 블럭을 움직여줌
    public void Move()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.UpArrow:
                Tetris_Turn();
                break;
            case ConsoleKey.DownArrow:
                ShiftCheck(0);
                break;
            case ConsoleKey.LeftArrow:
                ShiftCheck(-1);
                break;
            case ConsoleKey.RightArrow:
                ShiftCheck(1);
                break;
        }
        for (int i = 0; i < 4; ++i)
        {
            int x = tt.CenterCur[0] + tt.ShapeCur[i][0];
            int y = tt.CenterCur[1] + tt.ShapeCur[i][1];

            Screen.SetBlock(x, y, TBlock.BLOCK);
        }
        //Screen.SetBlock(Center_X, Center_Y, BlockType);
    }
    // 새로운 블럭을 호출
    public void SponNewBlock()
    {
        // 블럭 7개중에서 랜덤으로 호출한다.
        Random rand = new Random();
        tt.CurBlock = rand.Next(0, BlockTypeCount);
        /*int Creat_X = 
        int Creat_Y = ;*/

        // 블록의 센터를 스크린 중앙 위 좌표로 옮긴다.
        tt.CenterCur[0] = Screen.X_len() / 2; ;
        tt.CenterCur[1] = 3;
        // 스크린으로 그려준다.
        for (int i = 0; i < 4; ++i)
        {
            int x = tt.CenterCur[0] + Shapes[tt.CurBlock, i, 0];
            int y = tt.CenterCur[1] + Shapes[tt.CurBlock, i, 1];

            // 현재 블록에 정보를 저장한다.
            tt.ShapeCur[i][0] = Shapes[tt.CurBlock, i, 0];
            tt.ShapeCur[i][1] = Shapes[tt.CurBlock, i, 1];

            //현재 블록 정보를 스크린에 호출한다.
            Screen.SetBlock(x, y, TBlock.BLOCK);
        }
    }
    // 블럭을 얼만큼 이동 시킬것인가? - Move함수의 서브함수
    public void ShiftCheck(int Direction)
    {
        int[] NextCenter = new int[2];
        List<int[]> NextShape = new List<int[]>();
        NextShape = tt.ShapeCur;

        NextCenter[0] = tt.CenterCur[0] + Direction;
        NextCenter[1] = tt.CenterCur[1] + Convert.ToInt32(Direction == 0);

        for (int i = 0; i < 4; i++)
        {
            if (IsBlockOver(NextCenter, NextShape[i]) == true)
            {
                for (int k = 0; k < 4; ++k)
                {
                    int x = tt.CenterCur[0] + tt.ShapeCur[k][0];
                    int y = tt.CenterCur[1] + tt.ShapeCur[k][1];
                    Screen.SetBlock(x, y, TBlock.BLOCK);
                }
                return;
            }

            bool QueryResult = Collision(NextCenter, NextShape[i]);

            if (/*Direction == 0&&*/ QueryResult == true)
            {
                HoldBlock(tt.CenterCur[0], tt.CenterCur[1]);
                return;
            }

            if (Direction != 0 && QueryResult == true)
            {

            }
        }

        tt.CenterCur[0] += Direction;
        tt.CenterCur[1] += Convert.ToInt32(Direction == 0);

       
    }
    // 달고나 존맛탱, 충돌 검사
    public bool Collision(int[] NextCenter, int[] NextShpe)
    {
        int x = NextCenter[0] + NextShpe[0];
        int y = NextCenter[1] + NextShpe[1];

        if (Screen.GetBlock(x, y) == TBlock.WALL)
        {
            return true;
        }
        return false;
    }
    // 블럭을 정지시킨다.
    public void HoldBlock(int Center_X, int Center_Y)
    {
        for (int i = 0; i < 4; i++)
        {
            int x = Center_X + tt.ShapeCur[i][0];
            int y = Center_Y + tt.ShapeCur[i][1];

            Screen.SetBlock(x, y, TBlock.WALL);
        }

        SponNewBlock();
        ScoreProcess();
    }
    // 점수를 증가 시킨다.
    public void ScoreProcess()
    {
        tt.NowScore += 1;
    }
    // 블럭이 화면 밖에 나가는 걸 체크한다.
    public bool IsBlockOver(int[] NextCenter, int[] NextShape)
    {
        for (int i = 0; i < 4; i++)
        {
            int x = NextCenter[0] + NextShape[0];
            //int y = Next_Y + BlockShapes[CurrentBlock][i][1];
            if (x > Screen.X_len() -1|| x < 0)
            {
                return true;
            }
        }
        return false;
    }
    // 블럭이 회전한다.
    void Tetris_Turn()
    {
        List<int[]> NextShape = new List<int[]>();
        int[] NextCenter = tt.CenterCur;

        for (int i = 0; i < 4; ++i)
        {
            NextShape.Add(new int[2]);
            // 우선 회전을 시킴

            NextShape[i][0] = tt.ShapeCur[i][1];
            NextShape[i][1] = -tt.ShapeCur[i][0];
        }

        for (int i = 0; i < 4; ++i)
        {
            if(IsBlockOver(NextCenter, NextShape[i]) == false)
            {
                bool QueryResult = Collision(NextCenter, NextShape[i]);
                // 충돌 검사를 해본다.
                if (QueryResult == true)
                {
                    NextCenter[1] = tt.CenterCur[1] - 2;
                }
            }
            // 오버 검사를 해본다.
            else if (IsBlockOver(NextCenter, NextShape[i]) == true)
            {
                if (NextCenter[0] < Screen.X_len() / 2)
                {
                    NextCenter[0] = tt.CenterCur[0] + 2;
                }
                else if (NextCenter[0] > Screen.X_len() / 2)
                {
                    NextCenter[0] = tt.CenterCur[0] - 2;
                }
            }
        }
        // 검사 후에 적절하게 회전시킨다.
        tt.CenterCur = NextCenter;
        for (int i = 0; i < 4; ++i)
        {
            tt.ShapeCur[i][0] = NextShape[i][0];
            tt.ShapeCur[i][1] = NextShape[i][1];
        }
    }
}