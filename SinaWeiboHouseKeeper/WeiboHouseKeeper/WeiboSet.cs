using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiboControl
{
    public class WeiboSet
    {
        //是否启用
        public bool IsEnabled { get; set; }
        //是否开启随机发布频率
        public bool IsRandomPublish { get; set; }
        //固定频率
        public int FixedFrequency { get; set; }
        //随机频率下限
        public int RandomFrequencyMin { get; set; }
        //随机频率上限
        public int RandomFrequencyMax { get; set; }
        //随机频率
        public int RandomFrequency { get; private set; }

        private Random random = new Random();

        //重置随机频率
        public void ReSetRandomFrequency()
        {
            this.RandomFrequency = random.Next(this.RandomFrequencyMin, this.RandomFrequencyMax);
        }
    }
}
