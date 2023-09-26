using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class SegmentColors {

    /**
	 * This holds the segmentation colors for the control net
	 */

    public static Dictionary<string, Color32> segmentColorDict = new Dictionary<string, Color32>(){ 

        { "wall", new Color32(120, 120, 120, 255) },
        { "building;edifice", new Color32(180, 120, 120, 255) },
        { "sky", new Color32(6, 230, 230, 255) },
        { "floor;flooring", new Color32(80, 50, 50, 255) },
        { "tree", new Color32(4, 200, 3, 255) },
        { "ceiling", new Color32(120, 120, 80, 255) },
        { "road;route", new Color32(140, 140, 140, 255) },
        { "bed", new Color32(204, 5, 255, 255) },
        { "windowpane;window", new Color32(230, 230, 230, 255) },
        { "grass", new Color32(4, 250, 7, 255) },
        { "cabinet", new Color32(224, 5, 255, 255) },
        { "sidewalk;pavement", new Color32(235, 255, 7, 255) },
        { "person;individual;someone;somebody;mortal;soul", new Color32(150, 5, 61, 255) },
        { "earth;ground", new Color32(120, 120, 70, 255) },
        { "door;double;door", new Color32(8, 255, 51, 255) },
        { "table", new Color32(255, 6, 82, 255) },
        { "mountain;mount", new Color32(143, 255, 140, 255) },
        { "plant;flora;plant;life", new Color32(204, 255, 4, 255) },
        { "curtain;drape;drapery;mantle;pall", new Color32(255, 51, 7, 255) },
        { "chair", new Color32(204, 70, 3, 255) },
        { "car;auto;automobile;machine;motorcar", new Color32(0, 102, 200, 255) },
        { "water", new Color32(61, 230, 250, 255) },
        { "painting;picture", new Color32(255, 6, 51, 255) },
        { "sofa;couch;lounge", new Color32(11, 102, 255, 255) },
        { "shelf", new Color32(255, 7, 71, 255) },
        { "house", new Color32(255, 9, 224, 255) },
        { "sea", new Color32(9, 7, 230, 255) },
        { "mirror", new Color32(220, 220, 220, 255) },
        { "rug;carpet;carpeting", new Color32(255, 9, 92, 255) },
        { "field", new Color32(112, 9, 255, 255) },
        { "armchair", new Color32(8, 255, 214, 255) },
        { "seat", new Color32(7, 255, 224, 255) },
        { "fence;fencing", new Color32(255, 184, 6, 255) },
        { "desk", new Color32(10, 255, 71, 255) },
        { "rock;stone", new Color32(255, 41, 10, 255) },
        { "wardrobe;closet;press", new Color32(7, 255, 255, 255) },
        { "lamp", new Color32(224, 255, 8, 255) },
        { "bathtub;bathing;tub;bath;tub", new Color32(102, 8, 255, 255) },
        { "railing;rail", new Color32(255, 61, 6, 255) },
        { "cushion", new Color32(255, 194, 7, 255) },
        { "base;pedestal;stand", new Color32(255, 122, 8, 255) },
        { "box", new Color32(0, 255, 20, 255) },
        { "column;pillar", new Color32(255, 8, 41, 255) },
        { "signboard;sign", new Color32(255, 5, 153, 255) },
        { "chest;of;drawers;chest;bureau;dresser", new Color32(6, 51, 255, 255) },
        { "counter", new Color32(235, 12, 255, 255) },
        { "sand", new Color32(160, 150, 20, 255) },
        { "sink", new Color32(0, 163, 255, 255) },
        { "skyscraper", new Color32(140, 140, 140, 255) },
        { "fireplace;hearth;open;fireplace", new Color32(0250, 10, 15, 255) },
        { "refrigerator;icebox", new Color32(20, 255, 0, 255) },
        { "grandstand;covered;stand", new Color32(31, 255, 0, 255) },
        { "path", new Color32(255, 31, 0, 255) },
        { "stairs;steps", new Color32(255, 224, 0, 255) },
        { "runway", new Color32(153, 255, 0, 255) },
        { "case;display;case;showcase;vitrine", new Color32(0, 0, 255, 255) },
        { "pool;table;billiard;table;snooker;table", new Color32(255, 71, 0, 255) },
        { "pillow", new Color32(0, 235, 255, 255) },
        { "screen;door;screen", new Color32(0, 173, 255, 255) },
        { "stairway;staircase", new Color32(31, 0, 255, 255) },
        { "river", new Color32(11, 200, 200, 255) },
        { "bridge;span", new Color32(255 ,82, 0, 255) },
        { "bookcase", new Color32(0, 255, 245, 255) },
        { "blind;screen", new Color32(0, 61, 255, 255) },
        { "coffee;table;cocktail;table", new Color32(0, 255, 112, 255) },
        { "toilet;can;commode;crapper;pot;potty;stool;throne", new Color32(0, 255, 133, 255) },
        { "flower", new Color32(255, 0, 0, 255) },
        { "book", new Color32(255, 163, 0, 255) },
        { "hill", new Color32(255, 102, 0, 255) },
        { "bench", new Color32(194, 255, 0, 255) },
        { "countertop", new Color32(0, 143, 255, 255) },
        { "stove;kitchen;stove;range;kitchen;range;cooking;stove", new Color32(51, 255, 0, 255) },
        { "palm;palm;tree", new Color32(0, 82, 255, 255) },
        { "kitchen;island", new Color32(0, 255, 41, 255) },
        { "computer;computing;machine;computing;device;data;processor;electronic;computer;information;processing;system", new Color32(0, 255, 173, 255) },
        { "swivel;chair", new Color32(10, 0, 255, 255) },
        { "boat", new Color32(173, 255, 0, 255) },
        { "bar", new Color32(0, 255, 153, 255) },
        { "arcade;machine", new Color32(255, 92, 0, 255) },
        { "hovel;hut;hutch;shack;shanty", new Color32(255, 0, 255, 255) },
        { "bus;autobus;coach;charabanc;double-decker;jitney;motorbus;motorcoach;omnibus;passenger;vehicle", new Color32(255, 0, 245, 255) },
        { "towel", new Color32(255, 0, 102, 255) },
        { "light;light;source", new Color32(255, 173, 0, 255) },
        { "truck;motortruck", new Color32(255, 0, 20, 255) },
        { "tower", new Color32(255, 184, 184, 255) },
        { "chandelier;pendant;pendent", new Color32(0, 31, 255, 255) },
        { "awning;sunshade;sunblind", new Color32(0, 255, 61, 255) },
        { "streetlight;street;lamp", new Color32(0, 71, 255, 255) },
        { "booth;cubicle;stall;kiosk", new Color32(255, 0, 204, 255) },
        { "television;television;receiver;television;set;tv;tv;set;idiot;box;boob;tube;telly;goggle;box", new Color32(0, 255, 194, 255) },
        { "airplane;aeroplane;plane", new Color32(0, 255, 82, 255) },
        { "dirt;track", new Color32(0, 10, 255, 255) },
        { "apparel;wearing;apparel;dress;clothes", new Color32(0, 112, 255, 255) },
        { "pole", new Color32(51, 0, 255, 255) },
        { "land;ground;soil", new Color32(0, 194, 255, 255) },
        { "bannister;banister;balustrade;balusters;handrail", new Color32(0, 122, 255, 255) },
        { "escalator;moving;staircase;moving;stairway", new Color32(0, 255, 163, 255) },
        { "ottoman;pouf;pouffe;puff;hassock", new Color32(255, 153, 0, 255) },
        { "bottle", new Color32(0, 255, 10, 255) },
        { "buffet;counter;sideboard", new Color32(255, 112, 0, 255) },
        { "poster;posting;placard;notice;bill;card", new Color32(143, 255, 0, 255) },
        { "stage", new Color32(82, 0, 255, 255) },
        { "van", new Color32(163, 255, 0, 255) },
        { "ship", new Color32(255, 235, 0, 255) },
        { "fountain", new Color32(8, 184, 170, 255) },
        { "conveyer;belt;conveyor;belt;conveyer;conveyor;transporter", new Color32(133, 0, 255, 255) },
        { "canopy", new Color32(0, 255, 92, 255) },
        { "washer;automatic;washer;washing;machine", new Color32(184, 0, 255, 255) },
        { "plaything;toy", new Color32(255, 0, 31, 255) },
        { "swimming;pool;swimming;bath;natatorium", new Color32(0, 184, 255, 255) },
        { "stool", new Color32(0, 214, 255, 255) },
        { "barrel;cask", new Color32(255, 0, 112, 255) },
        { "basket;handbasket", new Color32(92, 255, 0, 255) },
        { "waterfall;falls", new Color32(0, 224, 255, 255) },
        { "tent;collapsible;shelter", new Color32(112, 224, 255, 255) },
        { "bag", new Color32(70, 184, 160, 255) },
        { "minibike;motorbike", new Color32(163, 0, 255, 255) },
        { "cradle", new Color32(153, 0, 255, 255) },
        { "oven", new Color32(71, 255, 0, 255) },
        { "ball", new Color32(255, 0, 163, 255) },
        { "food;solid;food", new Color32(255, 204, 0, 255) },
        { "step;stair", new Color32(255, 0, 143, 255) },
        { "tank;storage;tank", new Color32(0, 255, 235, 255) },
        { "trade;name;brand;name;brand;marque", new Color32(133, 255, 0, 255) },
        { "microwave;microwave;oven", new Color32(255, 0, 235, 255) },
        { "pot;flowerpot", new Color32(245, 0, 255, 255) },
        { "animal;animate;being;beast;brute;creature;fauna", new Color32(255, 0, 122, 255) },
        { "bicycle;bike;wheel;cycle", new Color32(255, 245, 0, 255) },
        { "lake", new Color32(10, 190, 212, 255) },
        { "dishwasher;dish;washer;dishwashing;machine", new Color32(214, 255, 0, 255) },
        { "screen;silver;screen;projection;screen", new Color32(0, 204, 255, 255) },
        { "blanket;cover", new Color32(20, 0, 255, 255) },
        { "sculpture", new Color32(255, 255, 0, 255) },
        { "hood;exhaust;hood", new Color32(0, 153, 255, 255) },
        { "sconce", new Color32(0, 41, 255, 255) },
        { "vase", new Color32(0, 255, 204, 255) },
        { "traffic;light;traffic;signal;stoplight", new Color32(41, 0, 255, 255) },
        { "tray", new Color32(41, 255, 0, 255) },
        { "ashcan;trash;can;garbage;can;wastebin;ash;bin;ash-bin;ashbin;dustbin;trash;barrel;trash;bin", new Color32(173, 0, 255, 255) },
        { "fan", new Color32(0, 245, 255, 255) },
        { "pier;wharf;wharfage;dock", new Color32(71, 0, 255, 255) },
        { "crt;screen", new Color32(122, 0, 255, 255) },
        { "plate", new Color32(0, 255, 184, 255) },
        { "monitor;monitoring;device", new Color32(0, 92, 255, 255) },
        { "bulletin;board;notice;board", new Color32(184, 255, 0, 255) },
        { "shower", new Color32(0, 133, 255, 255) },
        { "radiator", new Color32(255, 214, 0, 255) },
        { "glass;drinking;glass", new Color32(25, 194, 194, 255) },
        { "clock", new Color32(102, 255, 0, 255) },
        { "flag", new Color32(92, 0, 255, 255) }

    };


    public static Dictionary<string, Color32> NameSearch( string searchString){

        Dictionary<string, Color32> segmentColorFound = new Dictionary<string, Color32>();

        //for(int i = 0 ; i < SegmentColors.segmentColorDict.Count; i++){
        foreach(KeyValuePair<string, Color32> entry in SegmentColors.segmentColorDict){
            //// do something with entry.Value or entry.Key
            
            if( entry.Key.Contains(searchString) ){
                segmentColorFound.Add( entry.Key, entry.Value );
            }
        }

        return segmentColorFound;
    }

    public static string CleanName(string originalName){
        //swap out the ; for _
        string response = originalName.Replace(';', '_').Replace("-", "");
        if( response.Length > 32 ){
            response = response.Substring(0, 32);
        }
        return response;
    }

}