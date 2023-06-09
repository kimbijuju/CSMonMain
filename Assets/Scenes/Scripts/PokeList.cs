using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeList : MonoBehaviour
{
    // Start is called before the first frame update
    //Sprites
    public Sprite CathySprite;
    public Sprite EvanSprite;
    public Sprite EmilySprite;
    public Sprite NileshSprite;
    public Sprite OwenSprite;
    public Sprite SteveSprite;
    public Sprite MinghanSprite;
    public Sprite IzzieSprite;
    public Sprite NancySprite;
    public Sprite VanessaSprite;
    public Sprite DerrickSprite;
    public Sprite ByeonggukSprite;
    public Sprite DanielSprite;
    public Sprite YunxinSprite;
    public Sprite KrishSprite;
    public Sprite BijouSprite;
    public Sprite PeterSprite;
    public Sprite GraceSprite;
    public Sprite OmSprite;
    public Sprite AadyaSprite;
    public Sprite BowenSprite;
    public Sprite MehkiSprite;
    public Sprite RuthieSprite;
    public Sprite AbigailSprite;
    public Sprite VishwaSprite;
    public Sprite StevenSprite;
    public Sprite JessicaSprite;
    public Sprite AndrewSprite;
    public Sprite BennetSprite;
    public Sprite CalebSprite;
    

    public Sprite RobertSprite;
    public Sprite TateSprite;
    public Sprite GlowackiSprite;
    public Sprite LawSprite;
    public Sprite HamadaSprite;
    public Sprite YangSprite;
    
    
    
    //CSMon references
    public static CSMonRef Bijou;
    public static CSMonRef Byeongguk;
    public static CSMonRef Catherine;
    public static CSMonRef Daniel;
    public static CSMonRef Derrick;
    public static CSMonRef Emily;
    public static CSMonRef Evan;
    public static CSMonRef Krish;
    public static CSMonRef Minghan;
    public static CSMonRef Nilesh;
    public static CSMonRef Owen;
    public static CSMonRef Steve;
    public static CSMonRef Vanessa;
    public static CSMonRef Yunxin;
    public static CSMonRef Abigail;
    public static CSMonRef Jessica;
    public static CSMonRef Peter;
    public static CSMonRef Andrew;
    public static CSMonRef Vishwa;
    public static CSMonRef Nancy;
    public static CSMonRef Ruthie;
    public static CSMonRef Bowen;
    public static CSMonRef Steven;
    public static CSMonRef Grace;
    public static CSMonRef Om;
    public static CSMonRef Bennet;
    public static CSMonRef Caleb;
    public static CSMonRef Aadya;
    public static CSMonRef Mehki;
    public static CSMonRef Izzie;
    
    public static CSMonRef Robert;
    public static CSMonRef Tate; 
    public static CSMonRef Law;
    public static CSMonRef Glowacki;
    public static CSMonRef Hamada;
    public static CSMonRef Yang; 
    


    public class CSMonRef
    {
        public string name;
        public int hp;
        public int attk;
        public int speed;
        public int acc;
        public int critChance;
        public string attkName;
        public string type;
        public Sprite look;
        public string special;

        public CSMonRef(string n, int hitpoints, int attack, int spd, int accuracy, int cc, string aname, string t, Sprite sp, string specialty)
        {
            name=n;
            hp=hitpoints; 
            attk=attack;
            speed=spd;
            acc=accuracy;
            critChance=cc;
            attkName=aname;
            type=t;
            look=sp;
            special=specialty;
        }
    }
    
    
    public class CSMon{
        public double exp;
        public string status;
        public int currhp; 
        public CSMonRef refMon;
        public CSMon(double e, string s, int chp, CSMonRef r){
            exp=e;
            status=s;
            currhp=chp;
            refMon=r;

        }
        
        public string printStats(){
            string res="HP: "+this.currhp+"/"+(this.lvl()*this.refMon.hp)+"\nAttack: "+(this.lvl()*this.refMon.attk)+ "\nSpeed: "+(this.lvl()*this.refMon.speed)+"\nAccuracy: "+ this.refMon.acc+"% \nCrit Chance: "+this.refMon.critChance+"% \nType: "+this.refMon.type+"\nMove: " +this.refMon.attkName+"\n\n";
            if(this.refMon.special!="")
                res+=this.refMon.special;
            return res;
        } 
        public string printHeader(){
            string res="Lvl "+this.lvl()+" "+this.refMon.name;
            return res;
        }
        public int lvl(){
            return (int) this.exp;
        }
        public int totalHp(){
            return this.refMon.hp*this.lvl();
        }
        
        
    }  

    //your team of CSMon and enemies
    public static List<CSMon> ObtainedList= new List<CSMon>();
    public static List<CSMon> enemyList= new List<CSMon>();

    public static List<CSMon> allList=new List<CSMon>();
    public static List<CSMon> allEList=new List<CSMon>();

    //possible CSMon you can catch
    public static List<CSMonRef> Room1CSMon= new List<CSMonRef>();
    public static List<CSMonRef> Room2CSMon= new List<CSMonRef>();
    public static List<CSMonRef> Room3CSMon= new List<CSMonRef>();
    
    public static List<CSMonRef> Room9CSMon= new List<CSMonRef>();
    public static List<CSMonRef> LegendaryCSMon= new List<CSMonRef>();

    // Update is called once per frame
    void Start()
    {
         Aadya= new CSMonRef("Aadya", 100, 30, 10, 90, 30, "Shroomform", "Grass", AadyaSprite, "");
         Abigail= new CSMonRef("Abigail", 80, 90, 50, 30, 10, "Homerun", "Grass", AbigailSprite, "");
         Andrew= new CSMonRef("Andrew", 50, 60, 30, 80, 20, "Senior Blitz", "Fire", AndrewSprite, "Each time Senior Blitz lands, Andrew's speed doubles, capping at x8");
         Bennet= new CSMonRef("Bennet", 70, 30, 60, 90, 40, "Smoulder", "Fire", BennetSprite, "When Smoulder crits, it instead burns the target for the next 3 turns");
         Bijou= new CSMonRef("Bijou", 60, 30, 90, 85, 30, "Oppa", "Grass", BijouSprite, "");
         Bowen= new CSMonRef("Bowen", 70, 20, 80, 90, 20, "Rock Sweep", "Water", BowenSprite, "");
         Byeongguk= new CSMonRef("Byeongguk", 60, 15, 30, 40, 20, "Teaching Assistant", "Legendary", ByeonggukSprite, "Each time Teaching Assistant lands, Byeongguk's team's speed increases");
         Caleb= new CSMonRef("Caleb", 80, 30, 40, 70, 20, "Milky Water", "Water", CalebSprite, "If Milky Water lands, the opponent's next attack will do 50% damage");
         Catherine = new CSMonRef("Catherine", 65, 20, 85, 80, 10, "Osu Combo", "Legendary", CathySprite, "Each time Osu Combo lands, Catherine's next Osu Combo does x2 damage, capping at x8");
         Daniel= new CSMonRef("Daniel", 110, 25, 10, 90, 20, "Devour", "Grass", DanielSprite, "If Devour lands, Daniel heals for 50% of Devour's damage");
         Derrick= new CSMonRef("Derick", 50, 30, 70, 90, 20, "Tetris Smash", "Fire", DerrickSprite, "Uses the opponent's move, copying damage, crit chance, accuracy, and special effects");
         Emily = new CSMonRef("Emily", 30, 50, 100, 95, 20, "Knitting Needle", "Grass", EmilySprite, "");
         Evan= new CSMonRef("Evan", 70, 40, 60, 90, 30, "Breast Stroke", "Water", EvanSprite, "");
         Grace= new CSMonRef("Grace", 120, 10, 10, 80, 10, "Bungee Gum", "Fire", GraceSprite, "Opponents take 30% of damage they deal to Grace onto themselves");
         Izzie= new CSMonRef("Izzie", 50, 40, 80, 90, 30, "Sail Slash", "Water", IzzieSprite, "");
         Jessica= new CSMonRef("Jessica", 40, 80, 30, 80, 20, "Hollow Knight", "Grass", JessicaSprite, "");
         Krish=new CSMonRef("Krish", 100, 0, 0, 0, 0, "Copycat", "Grass", KrishSprite, "Uses the opponent's move, copying damage, crit chance, and accuracy");
         Mehki= new CSMonRef("Mehki", 70, 40, 40, 90, 30, "Kicking Spree", "Fire", MehkiSprite, "When Kicking Spree crits, it deals x2 damage instead of x1.5");
         Minghan=new CSMonRef("Minghan", 60, 70, 30, 60, 20, "Rocket", "Fire", MinghanSprite, "");
         Nancy=new CSMonRef("Nancy", 90, 30, 20, 60, 50, "Pitch Slap", "Water", NancySprite, "");
         Nilesh= new CSMonRef("Nilesh", 100, 40, 40, 70, 20, "Blazing Mustache", "Fire", NileshSprite, "If Blazing Mustache lands, Nilesh's HP is set to 70% its current amount");
         Om= new CSMonRef("Om", 40, 50, 90, 90, 20, "Omelette Strike", "Fire", OmSprite, "");
         Owen= new CSMonRef("Owen", 40, 60, 60, 80, 70, "Slap", "Grass", OwenSprite, "");   
         Peter= new CSMonRef("Peter", 100, 65, 25, 95, 20, "Snore", "Fire", PeterSprite, "Snore only does damage every 2nd usage");
         Ruthie= new CSMonRef("Ruthie", 40, 30, 70, 80, 20, "Hair Dew", "Water", RuthieSprite, "Opponent's accuracy is halved");
         Steve= new CSMonRef("Steve", 140 , 110, 10, 20, 10, "Rizz", "Water", SteveSprite, "If Rizz lands, Steve heals for 50% of Rizz's damage");
         Steven= new CSMonRef("Steven", 75, 35, 40, 80, 20, "Malicious Massage", "Water", StevenSprite, "Malicious Massage does more damage the lower Steven's current hp is");
         Vanessa= new CSMonRef("Vanessa", 50, 100, 95, 95, 20, "Volleyball Set", "Water", VanessaSprite, "Volleyball Set only does damage every 2nd usage");
         Vishwa= new CSMonRef("Vishwa", 60, 40, 40, 90, 20, "Shave", "Grass", VishwaSprite, "Vishwa's speed increases the lower his hp is");
         Yunxin= new CSMonRef("Yunxin", 30, 40, 90, 65, 20, "Hack", "Legendary", YunxinSprite, "If Hack lands, the opponent's next attack will fail");
         

         Robert= new CSMonRef("Robert", 90, 50, 10, 60, 20, "Block", "Legendary", RobertSprite, "");
         Law= new CSMonRef("Law", 60, 50, 50, 70, 20, "The Law", "Fire", LawSprite, "");
         Tate= new CSMonRef("Tate", 60, 50, 50, 70, 20, "Plus C", "Water", TateSprite, "");
         Glowacki= new CSMonRef("Glowacki", 60, 50, 50, 70, 20, "Dunk", "Grass", GlowackiSprite, "");
         Hamada= new CSMonRef("Hamada", 100, 20, 30, 70, 20, "Padlet", "Legendary", HamadaSprite, "");
         Yang= new CSMonRef("Yang", 30, 70, 80, 70, 20, "CTCI", "Legendary", YangSprite, "");
         
         
         //Adding possible CSMon to list of wild CSMon
         Room1CSMon.Add(Derrick);
         Room1CSMon.Add(Aadya);
         Room1CSMon.Add(Vishwa);
         Room1CSMon.Add(Steve);
         Room1CSMon.Add(Vanessa);
         Room1CSMon.Add(Om);
         
         Room2CSMon.Add(Krish);
         Room2CSMon.Add(Andrew);
         Room2CSMon.Add(Steven);
         Room2CSMon.Add(Caleb);
         Room2CSMon.Add(Bennet);
         Room2CSMon.Add(Daniel);
         
         Room3CSMon.Add(Minghan);
         Room3CSMon.Add(Izzie);
         Room3CSMon.Add(Emily);
         Room3CSMon.Add(Abigail);
         Room3CSMon.Add(Mehki);
         Room3CSMon.Add(Ruthie);


         Room9CSMon.Add(Grace);
         Room9CSMon.Add(Bowen);
         Room9CSMon.Add(Owen);
         Room9CSMon.Add(Peter);
         Room9CSMon.Add(Jessica);
         Room9CSMon.Add(Nancy);

         LegendaryCSMon.Add(Catherine);
         LegendaryCSMon.Add(Byeongguk);
         LegendaryCSMon.Add(Yunxin);


         int lvl=100;
         allList.Add(new PokeList.CSMon(lvl, "", Aadya.hp*100, Aadya));
         allList.Add(new PokeList.CSMon(lvl, "", Abigail.hp*100, Abigail));
         allList.Add(new PokeList.CSMon(lvl, "", Andrew.hp*100, Andrew));
         allList.Add(new PokeList.CSMon(lvl, "", Bennet.hp*100, Bennet));
         allList.Add(new PokeList.CSMon(lvl, "", Bijou.hp*100, Bijou));
         allList.Add(new PokeList.CSMon(lvl, "", Bowen.hp*100, Bowen));
         allList.Add(new PokeList.CSMon(lvl, "", Byeongguk.hp*100, Byeongguk));
         allList.Add(new PokeList.CSMon(lvl, "", Caleb.hp*100, Caleb));
         allList.Add(new PokeList.CSMon(lvl, "", Catherine.hp*100, Catherine));
         allList.Add(new PokeList.CSMon(lvl, "", Daniel.hp*100, Daniel));
         allList.Add(new PokeList.CSMon(lvl, "", Derrick.hp*100, Derrick));
         allList.Add(new PokeList.CSMon(lvl, "", Emily.hp*100, Emily));
         allList.Add(new PokeList.CSMon(lvl, "", Evan.hp*100, Evan));
         allList.Add(new PokeList.CSMon(lvl, "", Grace.hp*100, Grace));
         allList.Add(new PokeList.CSMon(lvl, "", Izzie.hp*100, Izzie));
         allList.Add(new PokeList.CSMon(lvl, "", Jessica.hp*100, Jessica));
         allList.Add(new PokeList.CSMon(lvl, "", Krish.hp*100, Krish));
         allList.Add(new PokeList.CSMon(lvl, "", Mehki.hp*100, Mehki));
         allList.Add(new PokeList.CSMon(lvl, "", Minghan.hp*100, Minghan));
         allList.Add(new PokeList.CSMon(lvl, "", Nancy.hp*100, Nancy));
         allList.Add(new PokeList.CSMon(lvl, "", Nilesh.hp*100, Nilesh));         
         allList.Add(new PokeList.CSMon(lvl, "", Om.hp*100, Om));
         allList.Add(new PokeList.CSMon(lvl, "", Owen.hp*100, Owen));
         allList.Add(new PokeList.CSMon(lvl, "", Peter.hp*100, Peter));
         allList.Add(new PokeList.CSMon(lvl, "", Ruthie.hp*100, Ruthie));
         allList.Add(new PokeList.CSMon(lvl, "", Steven.hp*100, Steven));
         allList.Add(new PokeList.CSMon(lvl, "", Steve.hp*100, Steve));
         allList.Add(new PokeList.CSMon(lvl, "", Vanessa.hp*100, Vanessa));
         allList.Add(new PokeList.CSMon(lvl, "", Vishwa.hp*100, Vishwa));
         allList.Add(new PokeList.CSMon(lvl, "", Yunxin.hp*100, Yunxin));



         allEList.Add(new PokeList.CSMon(lvl, "", Aadya.hp*100, Aadya));
         allEList.Add(new PokeList.CSMon(lvl, "", Abigail.hp*100, Abigail));
         allEList.Add(new PokeList.CSMon(lvl, "", Andrew.hp*100, Andrew));
         allEList.Add(new PokeList.CSMon(lvl, "", Bennet.hp*100, Bennet));
         allEList.Add(new PokeList.CSMon(lvl, "", Bijou.hp*100, Bijou));
         allEList.Add(new PokeList.CSMon(lvl, "", Bowen.hp*100, Bowen));
         allEList.Add(new PokeList.CSMon(lvl, "", Byeongguk.hp*100, Byeongguk));
         allEList.Add(new PokeList.CSMon(lvl, "", Caleb.hp*100, Caleb));
         allEList.Add(new PokeList.CSMon(lvl, "", Catherine.hp*100, Catherine));
         allEList.Add(new PokeList.CSMon(lvl, "", Daniel.hp*100, Daniel));
         allEList.Add(new PokeList.CSMon(lvl, "", Derrick.hp*100, Derrick));
         allEList.Add(new PokeList.CSMon(lvl, "", Emily.hp*100, Emily));
         allEList.Add(new PokeList.CSMon(lvl, "", Evan.hp*100, Evan));
         allEList.Add(new PokeList.CSMon(lvl, "", Grace.hp*100, Grace));
         allEList.Add(new PokeList.CSMon(lvl, "", Izzie.hp*100, Izzie));
         allEList.Add(new PokeList.CSMon(lvl, "", Jessica.hp*100, Jessica));
         allEList.Add(new PokeList.CSMon(lvl, "", Krish.hp*100, Krish));
         allEList.Add(new PokeList.CSMon(lvl, "", Mehki.hp*100, Mehki));
         allEList.Add(new PokeList.CSMon(lvl, "", Minghan.hp*100, Minghan));
         allEList.Add(new PokeList.CSMon(lvl, "", Nancy.hp*100, Nancy));
         allEList.Add(new PokeList.CSMon(lvl, "", Nilesh.hp*100, Nilesh));
         allEList.Add(new PokeList.CSMon(lvl, "", Om.hp*100, Om));
         allEList.Add(new PokeList.CSMon(lvl, "", Owen.hp*100, Owen));
         allEList.Add(new PokeList.CSMon(lvl, "", Peter.hp*100, Peter));
         allEList.Add(new PokeList.CSMon(lvl, "", Ruthie.hp*100, Ruthie));
         allEList.Add(new PokeList.CSMon(lvl, "", Steven.hp*100, Steven));
         allEList.Add(new PokeList.CSMon(lvl, "", Steve.hp*100, Steve));
         allEList.Add(new PokeList.CSMon(lvl, "", Vanessa.hp*100, Vanessa));
         allEList.Add(new PokeList.CSMon(lvl, "", Vishwa.hp*100, Vishwa));
         allEList.Add(new PokeList.CSMon(lvl, "", Yunxin.hp*100, Yunxin));
         
    }
}
