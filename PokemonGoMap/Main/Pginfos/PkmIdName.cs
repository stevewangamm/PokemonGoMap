using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Pgmasst.Properties;

namespace Pgmasst.Main.Pginfos
{
    public class PkmIdName
    {
        #region const

        private static readonly string[] PokemonCnNames = new string[]
        {
            "妙蛙种子",
            "妙蛙草",
            "妙蛙花",
            "小火龙",
            "火恐龙",
            "喷火龙",
            "杰尼龟",
            "卡咪龟",
            "水箭龟",
            "绿毛虫",
            "铁甲蛹",
            "巴大蝶",
            "独角虫",
            "铁壳蛹",
            "大针蜂",
            "波波",
            "比比鸟",
            "大比鸟",
            "小拉达",
            "拉达",
            "烈雀",
            "大嘴雀",
            "阿柏蛇",
            "阿柏怪",
            "皮卡丘",
            "雷丘",
            "穿山鼠",
            "穿山王",
            "尼多兰",
            "尼多娜",
            "尼多后",
            "尼多朗",
            "尼多力诺",
            "尼多王",
            "皮皮",
            "皮可西",
            "六尾",
            "九尾",
            "胖丁",
            "胖可丁",
            "超音蝠",
            "大嘴蝠",
            "走路草",
            "臭臭花",
            "霸王花",
            "派拉斯",
            "派拉斯特",
            "毛球",
            "摩鲁蛾",
            "地鼠",
            "三地鼠",
            "喵喵",
            "猫老大",
            "可达鸭",
            "哥达鸭",
            "猴怪",
            "火爆猴",
            "卡蒂狗",
            "风速狗",
            "蚊香蝌蚪",
            "蚊香君",
            "蚊香泳士",
            "凯西",
            "勇基拉",
            "胡地",
            "腕力",
            "豪力",
            "怪力",
            "喇叭芽",
            "口呆花",
            "大食花",
            "玛瑙水母",
            "毒刺水母",
            "小拳石",
            "隆隆石",
            "隆隆岩",
            "小火马",
            "烈焰马",
            "呆呆兽",
            "呆壳兽",
            "小磁怪",
            "三合一磁怪",
            "大葱鸭",
            "嘟嘟",
            "嘟嘟利",
            "小海狮",
            "白海狮",
            "臭泥",
            "臭臭泥",
            "大舌贝",
            "刺甲贝",
            "鬼斯",
            "鬼斯通",
            "耿鬼",
            "大岩蛇",
            "催眠貘",
            "引梦貘人",
            "大钳蟹",
            "巨钳蟹",
            "霹雳电球",
            "顽皮雷弹",
            "蛋蛋",
            "椰蛋树",
            "卡拉卡拉",
            "嘎啦嘎啦",
            "飞腿郎",
            "快拳郎",
            "大舌头",
            "瓦斯弹",
            "双弹瓦斯",
            "独角犀牛",
            "钻角犀兽",
            "吉利蛋",
            "蔓藤怪",
            "袋兽",
            "墨海马",
            "海刺龙",
            "角金鱼",
            "金鱼王",
            "海星星",
            "宝石海星",
            "魔墙人偶",
            "飞天螳螂",
            "迷唇姐",
            "电击兽",
            "鸭嘴火兽",
            "凯罗斯",
            "肯泰罗",
            "鲤鱼王",
            "暴鲤龙",
            "拉普拉斯",
            "百变怪",
            "伊布",
            "水伊布",
            "雷伊布",
            "火伊布",
            "多边兽",
            "菊石兽",
            "多刺菊石兽",
            "化石盔",
            "镰刀盔",
            "化石翼龙",
            "卡比兽",
            "急冻鸟",
            "闪电鸟",
            "火焰鸟",
            "迷你龙",
            "哈克龙",
            "快龙",
            "超梦",
            "梦幻",
        };

    private const string PokemonNameId = @"    <div>001 Bulbasaur</div>
	<div>002 Ivysaur</div>
	<div>003 Venusaur</div>
	<div>004 Charmander</div>
	<div>005 Charmeleon</div>
	<div>006 Charizard</div>
	<div>007 Squirtle</div>
	<div>008 Wartortle</div>
	<div>009 Blastoise</div>
	<div>010 Caterpie</div>
	<div>011 Metapod</div>
	<div>012 Butterfree</div>
	<div>013 Weedle</div>
	<div>014 Kakuna</div>
	<div>015 Beedrill</div>
	<div>016 Pidgey</div>
	<div>017 Pidgeotto</div>
	<div>018 Pidgeot</div>
	<div>019 Rattata</div>
	<div>020 Raticate</div>
	<div>021 Spearow</div>
	<div>022 Fearow</div>
	<div>023 Ekans</div>
	<div>024 Arbok</div>
	<div>025 Pikachu</div>
	<div>026 Raichu</div>
	<div>027 Sandshrew</div>
	<div>028 Sandslash</div>
	<div>029 Nidoran♀</div>
	<div>030 Nidorina</div>
	<div>031 Nidoqueen</div>
	<div>032 Nidoran♂</div>
	<div>033 Nidorino</div>
	<div>034 Nidoking</div>
	<div>035 Clefairy</div>
	<div>036 Clefable</div>
	<div>037 Vulpix</div>
	<div>038 Ninetales</div>
	<div>039 Jigglypuff</div>
	<div>040 Wigglytuff</div>
	<div>041 Zubat</div>
	<div>042 Golbat</div>
	<div>043 Oddish</div>
	<div>044 Gloom</div>
	<div>045 Vileplume</div>
	<div>046 Paras</div>
	<div>047 Parasect</div>
	<div>048 Venonat</div>
	<div>049 Venomoth</div>
	<div>050 Diglett</div>
	<div>051 Dugtrio</div>
	<div>052 Meowth</div>
	<div>053 Persian</div>
	<div>054 Psyduck</div>
	<div>055 Golduck</div>
	<div>056 Mankey</div>
	<div>057 Primeape</div>
	<div>058 Growlithe</div>
	<div>059 Arcanine</div>
	<div>060 Poliwag</div>
	<div>061 Poliwhirl</div>
	<div>062 Poliwrath</div>
	<div>063 Abra</div>
	<div>064 Kadabra</div>
	<div>065 Alakazam</div>
	<div>066 Machop</div>
	<div>067 Machoke</div>
	<div>068 Machamp</div>
	<div>069 Bellsprout</div>
	<div>070 Weepinbell</div>
	<div>071 Victreebel</div>
	<div>072 Tentacool</div>
	<div>073 Tentacruel</div>
	<div>074 Geodude</div>
	<div>075 Graveler</div>
	<div>076 Golem</div>
	<div>077 Ponyta</div>
	<div>078 Rapidash</div>
	<div>079 Slowpoke</div>
	<div>080 Slowbro</div>
	<div>081 Magnemite</div>
	<div>082 Magneton</div>
	<div>083 Farfetch'd</div>
	<div>084 Doduo</div>
	<div>085 Dodrio</div>
	<div>086 Seel</div>
	<div>087 Dewgong</div>
	<div>088 Grimer</div>
	<div>089 Muk</div>
	<div>090 Shellder</div>
	<div>091 Cloyster</div>
	<div>092 Gastly</div>
	<div>093 Haunter</div>
	<div>094 Gengar</div>
	<div>095 Onix</div>
	<div>096 Drowzee</div>
	<div>097 Hypno</div>
	<div>098 Krabby</div>
	<div>099 Kingler</div>
	<div>100 Voltorb</div>
	<div>101 Electrode</div>
	<div>102 Exeggcute</div>
	<div>103 Exeggutor</div>
	<div>104 Cubone</div>
	<div>105 Marowak</div>
	<div>106 Hitmonlee</div>
	<div>107 Hitmonchan</div>
	<div>108 Lickitung</div>
	<div>109 Koffing</div>
	<div>110 Weezing</div>
	<div>111 Rhyhorn</div>
	<div>112 Rhydon</div>
	<div>113 Chansey</div>
	<div>114 Tangela</div>
	<div>115 Kangaskhan</div>
	<div>116 Horsea</div>
	<div>117 Seadra</div>
	<div>118 Goldeen</div>
	<div>119 Seaking</div>
	<div>120 Staryu</div>
	<div>121 Starmie</div>
	<div>122 Mr.Mime</div>
	<div>123 Scyther</div>
	<div>124 Jynx</div>
	<div>125 Electabuzz</div>
	<div>126 Magmar</div>
	<div>127 Pinsir</div>
	<div>128 Tauros</div>
	<div>129 Magikarp</div>
	<div>130 Gyarados</div>
	<div>131 Lapras</div>
	<div>132 Ditto</div>
	<div>133 Eevee</div>
	<div>134 Vaporeon</div>
	<div>135 Jolteon</div>
	<div>136 Flareon</div>
	<div>137 Porygon</div>
	<div>138 Omanyte</div>
	<div>139 Omastar</div>
	<div>140 Kabuto</div>
	<div>141 Kabutops</div>
	<div>142 Aerodactyl</div>
	<div>143 Snorlax</div>
	<div>144 Articuno</div>
	<div>145 Zapdos</div>
	<div>146 Moltres</div>
	<div>147 Dratini</div>
	<div>148 Dragonair</div>
	<div>149 Dragonite</div>
	<div>150 Mewtwo</div>
	<div>151 Mew</div>";
        #endregion

        public static readonly List<Sprite> PkmNameIdList;
        private static Regex reg = new Regex(@"(?<id>\d{3}) (?<name>\w+)", RegexOptions.Compiled);

        static PkmIdName()
        {
            var i = 0;
            var smallIcons = new DirectoryInfo(Settings.Default.IconsDirectory).GetFiles("*.png").OrderBy(f => f.Name.Length).ToArray();
            var bigIcons = new DirectoryInfo(Settings.Default.HqIconsDirectory).GetFiles("*.png").OrderBy(f => f.Name.Length).ToArray();

            PkmNameIdList = reg.Matches(PokemonNameId).Cast<Match>().Select(m =>
            {
                Sprite sprite = new Sprite();
                sprite.Id = int.Parse(m.Groups["id"].Value);
                sprite.Name = m.Groups["name"].Value;
                sprite.NameCn = PokemonCnNames[i];
                sprite.BigIcon = Image.FromFile( bigIcons[i].FullName);
                sprite.SmallIcon = Image.FromFile(smallIcons[i].FullName);
                i += 1;
                return sprite;
            }).ToList();
        }

        public static int GetId(string name)
        {
            return PkmNameIdList.Single(p => p.Name == name || p.NameCn == name).Id;
        }

        public static string GetName(int id)
        {
            return PkmNameIdList.Single(p => p.Id == id).Name;
        }

        public static string GetCnName(int id)
        {
            return PkmNameIdList.Single(p => p.Id == id).NameCn;
        }
    }

    public class MoveSet
    {
        private static readonly Dictionary<string, string> MoveSetDic;

        static MoveSet()
        {
            int counter = 0;
            MoveSetDic = MoveSetOrigInfo.GroupBy(s => counter++/2)
                .Select(g => g.ToArray())
                .ToDictionary(a => a[0], a => a[1]);
        }

        public static string GetMove(string moveNo)
        {
            if (!MoveSetDic.ContainsKey(moveNo))
                return string.Empty;
            return MoveSetDic[moveNo];
        }

        private static readonly string[] MoveSetOrigInfo = new[]
        {
            "13" , "Wrap",
            "14" , "Hyper Beam",
            "16" , "Dark Pulse",
            "18" , "Sludge",
            "20" , "Vice Grip",
            "21" , "Flame Wheel",
            "22" , "Megahorn",
            "24" , "Flamethrower",
            "26" , "Dig",
            "28" , "Cross Chop",
            "30" , "Psybeam",
            "31" , "Earthquake",
            "32" , "Stone Edge",
            "33" , "Ice Punch",
            "34" , "Heart Stamp",
            "35" , "Discharge",
            "36" , "Flash Cannon",
            "38" , "Drill Peck",
            "39" , "Ice Beam",
            "40" , "Blizzard",
            "42" , "Heat Wave",
            "45" , "Aerial Ace",
            "46" , "Drill Run",
            "47" , "Petal Blizzard",
            "48" , "Mega Drain",
            "49" , "Bug Buzz",
            "50" , "Poison Fang",
            "51" , "Night Slash",
            "53" , "Bubble Beam",
            "54" , "Submission",
            "56" , "Low Sweep",
            "57" , "Aqua Jet",
            "58" , "Aqua Tail",
            "59" , "Seed Bomb",
            "60" , "Psyshock",
            "62" , "Ancient Power",
            "63" , "Rock Tomb",
            "64" , "Rock Slide",
            "65" , "Power Gem",
            "66" , "Shadow Sneak",
            "67" , "Shadow Punch",
            "69" , "Ominous Wind",
            "70" , "Shadow Ball",
            "72" , "Magnet Bomb",
            "74" , "Iron Head",
            "75" , "Parabolic Charge",
            "77" , "Thunder Punch",
            "78" , "Thunder",
            "79" , "Thunderbolt",
            "80" , "Twister",
            "82" , "Dragon Pulse",
            "83" , "Dragon Claw",
            "84" , "Disarming Voice",
            "85" , "Draining Kiss",
            "86" , "Dazzling Gleam",
            "87" , "Moonblast",
            "88" , "Play Rough",
            "89" , "Cross Poison",
            "90" , "Sludge Bomb",
            "91" , "Sludge Wave",
            "92" , "Gunk Shot",
            "94" , "Bone Club",
            "95" , "Bulldoze",
            "96" , "Mud Bomb",
            "99" , "Signal Beam",
            "100" , "X Scissor",
            "101" , "Flame Charge",
            "102" , "Flame Burst",
            "103" , "Fire Blast",
            "104" , "Brine",
            "105" , "Water Pulse",
            "106" , "Scald",
            "107" , "Hydro Pump",
            "108" , "Psychic",
            "109" , "Psystrike",
            "111" , "Icy Wind",
            "114" , "Giga Drain",
            "115" , "Fire Punch",
            "116" , "Solar Beam",
            "117" , "Leaf Blade",
            "118" , "Power Whip",
            "121" , "Air Cutter",
            "122" , "Hurricane",
            "123" , "Brick Break",
            "125" , "Swift",
            "126" , "Horn Attack",
            "127" , "Stomp",
            "129" , "Hyper Fang",
            "131" , "Body Slam",
            "132" , "Rest",
            "133" , "Struggle",
            "200" , "Fury Cutter",
            "201" , "Bug Bite",
            "202" , "Bite",
            "203" , "Sucker Punch",
            "204" , "Dragon Breath",
            "205" , "Thunder Shock",
            "206" , "Spark",
            "207" , "Low Kick",
            "208" , "Karate Chop",
            "209" , "Ember",
            "210" , "Wing Attack",
            "211" , "Peck",
            "212" , "Lick",
            "213" , "Shadow Claw",
            "214" , "Vine Whip",
            "215" , "Razor Leaf",
            "216" , "Mud Shot",
            "217" , "Ice Shard",
            "218" , "Frost Breath",
            "219" , "Quick Attack",
            "220" , "Scratch",
            "221" , "Tackle",
            "222" , "Pound",
            "223" , "Cut",
            "224" , "Poison Jab",
            "225" , "Acid",
            "226" , "Psycho Cut",
            "227" , "Rock Throw",
            "228" , "Metal Claw",
            "229" , "Bullet Punch",
            "230" , "Water Gun",
            "231" , "Splash",
            "233" , "Mud Slap",
            "234" , "Zen Headbutt",
            "235" , "Confusion",
            "236" , "Poison Sting",
            "237" , "Bubble",
            "238" , "Feint Attack",
            "239" , "Steel Wing",
            "240" , "Fire Fang",
            "241" , "Rock Smash",
            "242" , "Transform"
        };

    }
}