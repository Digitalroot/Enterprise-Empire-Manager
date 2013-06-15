namespace EEM.Common.Adapters
{
  public enum ServerCommand
  {
    
    AbandonCity, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930"}
    AllianceGetContinentCount, // {"session":"00000000-0235-4b4b-a301-e4491e4c5be7"}
    AllianceGetCount, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    AllianceGetRange, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","start":0,"end":99,"sort":-1,"ascending":true}
    CancelBuild, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","cityid":"15794563","queueid":670765890}
    CancelUnitOrder, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20971776","id":22798515,"isDelayed":false}
    CityNoteSet, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","cityid":"15597953","reference":"Resource Vault","text":"Max Resource storage and trading.\nAlso max hideouts. \nShould have a balista Def\n\nDump to 370:231 CA N 01\n\nLand at 21:157\nz"}
    CreateMoonStone, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930","buildingid":69388}
    DemolishBuilding, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930","buildingid":68361}
    DowngradeBuilding, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930","buildingid":68360,"buildingType":7}
    GetBuildMinisterOptions, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    GetBuildingInfo, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930","buildingid":68360}
    GetBuildingUpgradeInfo, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930","buildingid":68360}
    GetDefenceMinisterOptions, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    GetDistance, // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","target":13500771}
    GetMilitaryMinisterOptions, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    GetOrderTargetInfo, // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","cityid":"10485779","x":"385","y":"238"}
    GetPlayerInfo, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    GetPublicAllianceInfo, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","id":13221}
    GetPublicAllianceMemberList, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","id":13221}
    GetPublicCityInfo, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","id":16974186}
    GetPublicPlayerInfoByName, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","name":"Kryllik"}
    GetReport,
    GetServerInfo,
    GetUnitProductionInfo, // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","cityid":"10485779"}
    IGMSendMsg, // {"session":"00000000-7e5b-45bc-a3a3-40c93f60dbb3","target":"PlayerName","subject":"test","body":"test"}
    IGMBulkSendMsg,
    IGMBulkDeleteMsg, // {"session":"00000000-7e5b-45bc-a3a3-40c93f60dbb3","ids":["13160280"],"f":442353,"a":false}
    IGMGetMsgCount,
    IGMGetFolders,
    IGMGetMsgHeader, // {"session":"00000000-7e5b-45bc-a3a3-40c93f60dbb3","folder":200093,"start":0,"end":49,"sort":3,"ascending":false,"direction":true}
    IGMGetMsg,
    MoveBuildEntryTo, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","cityid":"15729020","queue1id":669728783,"queuePosition":1}
    OpenSession,
    OrderUnits, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20971776","units":[{"t":"10","c":2748}],"targetPlayer":"Dienekes","targetCity":"254:321","order":4,"transport":1,"timeReferenceType":1,"referenceTimeUTCMillis":0}
    PlayerGetAnonymousStatisticOption, // {"session":"00000000-0235-4b4b-a301-e4491e4c5be7"}
    PlayerGetContinentCount, // {"session":"00000000-0235-4b4b-a301-e4491e4c5be7"}
    PlayerGetCount, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    PlayerGetCountAndIndex, // {"session":"00000000-0235-4b4b-a301-e4491e4c5be7","continent":-1,"sort":0,"ascending":true,"datatype":0}
    PlayerGetRange, // {"session":"00000000-0235-4b4b-a301-e4491e4c5be7","start":0,"end":149,"continent":-1,"sort":0,"ascending":true,"datatype":0}
    Poll,
    QuestGetActive, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    RenameCity,
    ReportBulkDelete, // {"session":"00000000-fe46-486d-a0b6-a78ab7380a67","ids":[109699592]}
    ReportGetCount, // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","folder":0,"city":-1}
    ReportGetHeader,
    SetBuildMinisterOptions, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","keepOrder":true,"payOnResourceOverflow":true}
    SetDefenceMinisterOptions, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","keepOrder":true,"payOnResourceOverflow":true}
    SetMilitaryMinisterOptions, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","raidTroopPercent":85}
    SetResoOptions, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","o":{"w":false,"s":false,"i":false,"f":true,"g":false,"c":true,"o":false,"ic":false,"fa":true,"p":true,"cs":6,"pa":24,"mw":48,"a":true}}
    SocialFriendListInvalidate, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    SocialGetIgnore, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    SortBuild, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","cityid":"15729020"}
    StartOver, // {"session":"00000000-793b-4168-bfb5-4b8a9dbb53bf","cityName":"City of Playername"} - returns 0
    SurveyGetComplete, // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa"}
    TradeDirect, // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","cityid":"10485779","res":[{"t":1,"c":225000},{"t":2,"c":575000}],"tradeTransportType":1,"targetPlayer":"MyNAme","targetCity":"20:160"}
    TradeSearchResources, // {"session":"00000000-6ac8-4623-b814-2efcb086a86d","cityid":"15597953","resType":2,"minResource":0,"maxTime":36000}
    UpgradeBuilding, // {"session":"00000000-96e4-41f6-b3ce-1ac451b6b5b8","cityid":"15663491","buildingid":68108,"buildingType":18,"isPaid":true}
  }
}