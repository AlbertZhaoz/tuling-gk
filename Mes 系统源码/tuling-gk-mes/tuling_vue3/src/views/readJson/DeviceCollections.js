let data = {
  "DeviceCollections": {
    "DeviceCollection": [
      {
        "Id": "1",
        "Name": "环形1线",
        "IpAddress": "127.0.0.1",
        //"IpAddress": "192.168.1.2",
        "Port": "102",
        "ConnectTimeOut": "3000",
        "ReceiveTimeOut": "3000",
        "SetHeartAddress": "DB50.0.0",
        "ProductType": "short,DB50.2.0",
        "StationSeqs": [
          {
            "Id": "1",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op10",
            "RfidRisingEdge": "DB50.100.0",
            "RfidResponseEdge": "DB50.100.1",
            "RisingEdge": "DB50.100.2",
            "ResponseEdge": "DB50.100.3",
            "StationAllow": "short,DB50.102.0",
            "RfidLabel": "short,DB50.104.0",
            "SqlOperate": "None",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op10Beat",
                "TypeAndDb": "int,DB50.106.0"
              }
            ]
          },
          {
            "Id": "2",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op20",  
            "RfidRisingEdge": "DB50.200.0",
            "RfidResponseEdge": "DB50.200.1",
            "RisingEdge": "DB50.200.2",
            "ResponseEdge": "DB50.200.3",
            "StationAllow": "short,DB50.202.0",
            "RfidLabel": "short,DB50.204.0",
            "SqlOperate": "Insert",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op20Beat",
                "TypeAndDb": "int,DB50.206.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "ProductCode",
                "TypeAndDb": "string,DB50.210.0,16"
              }
            ]
          },
          {
            "Id": "3",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op30",
            "RfidRisingEdge": "DB50.300.0",
            "RfidResponseEdge": "DB50.300.1",
            "RisingEdge": "DB50.300.2",
            "ResponseEdge": "DB50.300.3",
            "StationAllow": "short,DB50.302.0",
            "RfidLabel": "short,DB50.304.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op30Beat",
                "TypeAndDb": "int,DB50.306.0"
              }
            ]
          },
          {
            "Id": "4",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op40",
            "RfidRisingEdge": "DB50.400.0",
            "RfidResponseEdge": "DB50.400.1",
            "RisingEdge": "DB50.400.2",
            "ResponseEdge": "DB50.400.3",
            "StationAllow": "short,DB50.402.0",
            "RfidLabel": "short,DB50.404.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op40Beat",
                "TypeAndDb": "int,DB50.406.0"
              }
            ]
          },
          {
            "Id": "5",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op50",
            "RfidRisingEdge": "DB50.500.0",
            "RfidResponseEdge": "DB50.500.1",
            "RisingEdge": "DB50.500.2",
            "ResponseEdge": "DB50.500.3",
            "StationAllow": "short,DB50.502.0",
            "RfidLabel": "short,DB50.504.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op50Beat",
                "TypeAndDb": "int,DB50.506.0"
              }
            ]
          },
          {
            "Id": "6",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op60",
            "RfidRisingEdge": "DB50.600.0",
            "RfidResponseEdge": "DB50.600.1",
            "RisingEdge": "DB50.600.2",
            "ResponseEdge": "DB50.600.3",
            "StationAllow": "short,DB50.602.0",
            "RfidLabel": "short,DB50.604.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op60Beat",
                "TypeAndDb": "int,DB50.606.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op60Pressure",
                "TypeAndDb": "short,DB50.610.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op60Displacement",
                "TypeAndDb": "short,DB50.612.0"
              },
              {
                "Id": "4",
                "SeqId": "1",
                "Sort": "4",
                "SqlColumnName": "Op60DisplacementUpper",
                "TypeAndDb": "float,DB50.614.0"
              },
              {
                "Id": "5",
                "SeqId": "1",
                "Sort": "5",
                "SqlColumnName": "Op60DisplacementLower",
                "TypeAndDb": "float,DB50.618.0"
              }
            ]
          },
          {
            "Id": "7",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op70",
            "RfidRisingEdge": "DB50.700.0",
            "RfidResponseEdge": "DB50.700.1",
            "RisingEdge": "DB50.700.2",
            "ResponseEdge": "DB50.700.3",
            "StationAllow": "short,DB50.702.0",
            "RfidLabel": "short,DB50.704.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op70Beat",
                "TypeAndDb": "int,DB50.706.0"
              }
            ]
          },
          {
            "Id": "8",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op80",
            "RfidRisingEdge": "DB50.800.0",
            "RfidResponseEdge": "DB50.800.1",
            "RisingEdge": "DB50.800.2",
            "ResponseEdge": "DB50.800.3",
            "StationAllow": "short,DB50.802.0",
            "RfidLabel": "short,DB50.804.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op80Beat",
                "TypeAndDb": "int,DB50.806.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "ProductCode",
                "TypeAndDb": "string,DB50.810.0,16"
              }
            ]
          },
          {
            "Id": "9",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op90",
            "RfidRisingEdge": "DB50.900.0",
            "RfidResponseEdge": "DB50.900.1",
            "RisingEdge": "DB50.900.2",
            "ResponseEdge": "DB50.900.3",
            "StationAllow": "short,DB50.902.0",
            "RfidLabel": "short,DB50.904.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op90Beat",
                "TypeAndDb": "int,DB50.906.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op90DisplaceResult",
                "TypeAndDb": "short,DB50.910.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op90DisplaceValue",
                "TypeAndDb": "float,DB50.912.0"
              },
              {
                "Id": "4",
                "SeqId": "1",
                "Sort": "4",
                "SqlColumnName": "Op90IV3Result",
                "TypeAndDb": "short,DB50.916.0"
              }

            ]
          },
          {
            "Id": "10",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op100",
            "RfidRisingEdge": "DB50.1000.0",
            "RfidResponseEdge": "DB50.1000.1",
            "RisingEdge": "DB50.1000.2",
            "ResponseEdge": "DB50.1000.3",
            "StationAllow": "short,DB50.1002.0",
            "RfidLabel": "short,DB50.1004.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op100Beat",
                "TypeAndDb": "int,DB50.1006.0"
              }
            ]
          },
          {
            "Id": "11",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op110",
            "RfidRisingEdge": "DB50.1100.0",
            "RfidResponseEdge": "DB50.1100.1",
            "RisingEdge": "DB50.1100.2",
            "ResponseEdge": "DB50.1100.3",
            "StationAllow": "short,DB50.1102.0",
            "RfidLabel": "short,DB50.1104.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op110Beat",
                "TypeAndDb": "int,DB50.1106.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op110IV3Result",
                "TypeAndDb": "short,DB50.1110.0"
              }
            ]
          },
          {
            "Id": "12",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op120",
            // Rfid 上升延 这边有一个特殊情况 Op120 工站要根据 1200.4 bool false结束 true开启
            // Op120Torque float,DB50.1210.0
            "RfidRisingEdge": "DB50.1200.0",
            "RfidResponseEdge": "DB50.1200.1",
            "RisingEdge": "DB50.1200.2",
            "ResponseEdge": "DB50.1200.3",
            "StationAllow": "short,DB50.1202.0",
            "RfidLabel": "short,DB50.1204.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op120Beat",
                "TypeAndDb": "int,DB50.1206.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op120Torque",
                "TypeAndDb": "float,DB50.1210.0"
              }
            ]
          },
          {
            "Id": "13",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op130",
            "RfidRisingEdge": "DB50.1300.0",
            "RfidResponseEdge": "DB50.1300.1",
            "RisingEdge": "DB50.1300.2",
            "ResponseEdge": "DB50.1300.3",
            "StationAllow": "short,DB50.1302.0",
            "RfidLabel": "short,DB50.1304.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op130Beat",
                "TypeAndDb": "int,DB50.1206.0"
              }
            ]
          },
          {
            "Id": "14",
            "DeviceId": "1",
            "DeviceName": "环形1线",
            "SeqName": "Op140",
            "RfidRisingEdge": "DB50.1400.0",
            "RfidResponseEdge": "DB50.1400.1",
            "RisingEdge": "DB50.1400.2",
            "ResponseEdge": "DB50.1400.3",
            "StationAllow": "short,DB50.1402.0",
            "RfidLabel": "short,DB50.1404.0",
            "SqlOperate": "Ignore",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op140Beat",
                "TypeAndDb": "int,DB50.1406.0"
              }
            ]
          }
        ]
      },
      {
        "Id": "2",
        "Name": "环形2线",
        "IpAddress": "192.168.1.5",
        //"IpAddress": "127.0.0.1",
        "Port": "102",
        "ConnectTimeOut": "3000",
        "ReceiveTimeOut": "3000",
        "SetHeartAddress": "DB50.0.0",
        "ProductType": "short,DB50.2.0",
        "StationSeqs": [
          {
            "Id": "1",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op150", // 放五个零件，显示五个零件在线，无轴承码
            "RfidRisingEdge": "DB50.100.0",
            "RfidResponseEdge": "DB50.100.1",
            "RisingEdge": "DB50.100.2",
            "ResponseEdge": "DB50.100.3",
            "StationAllow": "short,DB50.102.0",
            "RfidLabel": "short,DB50.104.0",
            "SqlOperate": "None",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op150Beat",
                "TypeAndDb": "int,DB50.106.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "RunCode",
                "TypeAndDb": "string,DB50.110.0,38"
              }
            ]
          },
          {
            "Id": "2",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op160",
            "RfidRisingEdge": "DB50.200.0",
            "RfidResponseEdge": "DB50.200.1",
            "RisingEdge": "DB50.200.2",
            "ResponseEdge": "DB50.200.3",
            "StationAllow": "short,DB50.202.0",
            "RfidLabel": "short,DB50.204.0",
            "SqlOperate": "None",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op160Beat",
                "TypeAndDb": "int,DB50.206.0"
              }
            ]
          },
          {
            "Id": "3",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op170",
            "RfidRisingEdge": "DB50.300.0",
            "RfidResponseEdge": "DB50.300.1",
            "RisingEdge": "DB50.300.2",
            "ResponseEdge": "DB50.300.3",
            "StationAllow": "short,DB50.302.0",
            "RfidLabel": "short,DB50.304.0",
            "SqlOperate": "None",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op170Beat",
                "TypeAndDb": "int,DB50.306.0"
              }
            ]
          },
          {
            "Id": "4",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op180_1",
            "RfidRisingEdge": "DB50.400.0",
            "RfidResponseEdge": "DB50.400.1",
            "RisingEdge": "DB50.400.2",
            "ResponseEdge": "DB50.400.3",
            "StationAllow": "short,DB50.402.0",
            "RfidLabel": "short,DB50.404.0",
            "SqlOperate": "None",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op180_1Beat",
                "TypeAndDb": "int,DB50.406.0"
              }
            ]
          },
          {
            "Id": "5",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op180_2",
            "RfidRisingEdge": "DB50.500.0",
            "RfidResponseEdge": "DB50.500.1",
            "RisingEdge": "DB50.500.2",
            "ResponseEdge": "DB50.500.3",
            "StationAllow": "short,DB50.502.0",
            "RfidLabel": "short,DB50.504.0",
            "SqlOperate": "None",
            "ReadData": [
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op180_2Beat",
                "TypeAndDb": "int,DB50.506.0"
              }
            ]
          },
          {
            "Id": "6",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            // 数据插入，数据绑定  
            // 插入数据，将托盘上 Op150、Op160、Op170、Op180_1、Op180_2 等数据转移到壳体码上 壳体码和执行器码绑定
            "SeqName": "Op180_3",
            "RfidRisingEdge": "DB50.600.0",
            "RfidResponseEdge": "DB50.600.1",
            "RisingEdge": "DB50.600.2",
            "ResponseEdge": "DB50.600.3",
            "StationAllow": "short,DB50.602.0",
            "RfidLabel": "short,DB50.604.0",
            "SqlOperate": "Insert",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op180_3Beat",
                "TypeAndDb": "int,DB50.606.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op180_3Torque",
                "TypeAndDb": "float,DB50.610.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op180_3Angle",
                "TypeAndDb": "float,DB50.614.0"
              },
              {
                "Id": "4",
                "SeqId": "1",
                "Sort": "4",
                "SqlColumnName": "Op180_3TorqueResult", //判断是否 NG，1 OK 2 NG
                "TypeAndDb": "short,DB50.618.0"
              },
              {
                "Id": "5",
                "SeqId": "1",
                "Sort": "5",
                "SqlColumnName": "Op180_3Torque2",
                "TypeAndDb": "float,DB50.620.0"
              },
              {
                "Id": "6",
                "SeqId": "1",
                "Sort": "6",
                "SqlColumnName": "Op180_3Angle2",
                "TypeAndDb": "float,DB50.624.0"
              },
              {
                "Id": "7",
                "SeqId": "1",
                "Sort": "7",
                "SqlColumnName": "Op180_3TorqueResult2", // 判断是否 NG，1 OK 2 NG
                "TypeAndDb": "short,DB50.628.0"
              },
              {
                "Id": "8",
                "SeqId": "1",
                "Sort": "8",
                "SqlColumnName": "ShellCode", // 壳体码 轴承二合一，绑定在一起，数据承载在壳体码上
                "TypeAndDb": "string,DB50.630.0,16"
              },
              {
                "Id": "9",
                "SeqId": "1",
                "Sort": "9",
                "SqlColumnName": "ProductCode", // 轴承码
                "TypeAndDb": "string,DB50.646.0,16"
              }
            ]
          },
          {
            "Id": "7",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op190", // 球阀组装 
            "RfidRisingEdge": "DB50.700.0",
            "RfidResponseEdge": "DB50.700.1",
            "RisingEdge": "DB50.700.2",
            "ResponseEdge": "DB50.700.3",
            "StationAllow": "short,DB50.702.0",
            "RfidLabel": "short,DB50.704.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op190Beat",
                "TypeAndDb": "int,DB50.706.0"
              }
            ]
          },
          {
            "Id": "8",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op200_1", // 堵帽
            "RfidRisingEdge": "DB50.800.0",
            "RfidResponseEdge": "DB50.800.1",
            "RisingEdge": "DB50.800.2",
            "ResponseEdge": "DB50.800.3",
            "StationAllow": "short,DB50.802.0",
            "RfidLabel": "short,DB50.804.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op200_1Beat",
                "TypeAndDb": "int,DB50.806.0"
              }
            ]
          },
          {
            "Id": "9",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op200_2", // 堵帽
            "RfidRisingEdge": "DB50.900.0",
            "RfidResponseEdge": "DB50.900.1",
            "RisingEdge": "DB50.900.2",
            "ResponseEdge": "DB50.900.3",
            "StationAllow": "short,DB50.902.0",
            "RfidLabel": "short,DB50.904.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op200_2Beat",
                "TypeAndDb": "int,DB50.906.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op200_2IV3Result",
                "TypeAndDb": "float,DB50.910.0"
              }
            ]
          },
          {
            "Id": "10",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op210",
            "RfidRisingEdge": "DB50.1000.0",
            "RfidResponseEdge": "DB50.1000.1",
            "RisingEdge": "DB50.1000.2",
            "ResponseEdge": "DB50.1000.3",
            "StationAllow": "short,DB50.1002.0",
            "RfidLabel": "short,DB50.1004.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op210Beat",
                "TypeAndDb": "int,DB50.1006.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op210Torque",
                "TypeAndDb": "float,DB50.1010.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op210Angle",
                "TypeAndDb": "float,DB50.1014.0"
              },
              {
                "Id": "4",
                "SeqId": "1",
                "Sort": "4",
                "SqlColumnName": "Op210TorqueResult", // 螺丝枪 1 OK 2 NG
                "TypeAndDb": "short,DB50.1018.0"
              }
            ]
          },
          {
            "Id": "11",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op220", // OK  NG下线  要么发1，要么发3
            "RfidRisingEdge": "DB50.1100.0",
            "RfidResponseEdge": "DB50.1100.1",
            "RisingEdge": "DB50.1100.2",
            "ResponseEdge": "DB50.1100.3",
            "StationAllow": "short,DB50.1102.0",
            "RfidLabel": "short,DB50.1104.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op220Beat",
                "TypeAndDb": "int,DB50.1106.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op220DisplaceResult",
                "TypeAndDb": "short,DB50.1110.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op220Displace",
                "TypeAndDb": "float,DB50.1112.0"
              }
            ]
          },
          {
            "Id": "12",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op230_1", // 氦检
            "RfidRisingEdge": "DB50.1200.0",
            "RfidResponseEdge": "DB50.1200.1",
            "RisingEdge": "DB50.1200.2",
            "ResponseEdge": "DB50.1200.3",
            "StationAllow": "short,DB50.1202.0",
            "RfidLabel": "short,DB50.1204.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op230_1Beat",
                "TypeAndDb": "int,DB50.1206.0"
              }
            ]
          },
          {
            "Id": "13",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op230_2",
            "RfidRisingEdge": "DB50.1300.0",
            "RfidResponseEdge": "DB50.1300.1",
            "RisingEdge": "DB50.1300.2",
            "ResponseEdge": "DB50.1300.3",
            "StationAllow": "short,DB50.1302.0",
            "RfidLabel": "short,DB50.1304.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op230_2Beat",
                "TypeAndDb": "int,DB50.1206.0"
              }
            ]
          },
          {
            "Id": "14",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op230_3", // 需要从氦检数据库抓取数据
            "RfidRisingEdge": "DB50.1400.0",
            "RfidResponseEdge": "DB50.1400.1",
            "RisingEdge": "DB50.1400.2",
            "ResponseEdge": "DB50.1400.3",
            "StationAllow": "short,DB50.1402.0",
            "RfidLabel": "short,DB50.1404.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op230_3Result",
                "TypeAndDb": "short,DB50.1406.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op230_3Beat",
                "TypeAndDb": "int,DB50.1408.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.1412.0,16"
              }
            ]
          },
          {
            "Id": "15",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op230_4", // 需要从氦检数据库抓取数据
            "RfidRisingEdge": "DB50.1500.0",
            "RfidResponseEdge": "DB50.1500.1",
            "RisingEdge": "DB50.1500.2",
            "ResponseEdge": "DB50.1500.3",
            "StationAllow": "short,DB50.1502.0",
            "RfidLabel": "short,DB50.1504.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op230_4Result",
                "TypeAndDb": "short,DB50.1506.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op230_4Beat",
                "TypeAndDb": "int,DB50.1508.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.1512.0,16"
              }
            ]
          },
          {
            "Id": "16",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op240_1", // 读完标签上升沿能做就直接写壳体码，string,DB50.1610.0
            "RfidRisingEdge": "DB50.1600.0",
            "RfidResponseEdge": "DB50.1600.1",
            "RisingEdge": "DB50.1600.2",
            "ResponseEdge": "DB50.1600.3",
            "StationAllow": "short,DB50.1602.0",
            "RfidLabel": "short,DB50.1604.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op230_4Beat",
                "TypeAndDb": "int,DB50.1606.0"
              }
            ]
          },
          {
            "Id": "16",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op240_2",
            "RfidRisingEdge": "DB50.1700.0",
            "RfidResponseEdge": "DB50.1700.1",
            "RisingEdge": "DB50.1700.2",
            "ResponseEdge": "DB50.1700.3",
            "StationAllow": "short,DB50.1702.0",
            "RfidLabel": "short,DB50.1704.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op240_2Result",
                "TypeAndDb": "short,DB50.1706.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op240_2Beat",
                "TypeAndDb": "int,DB50.1708.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "ShellCode", // rfid 壳体码绑定
                "TypeAndDb": "string,DB50.1712.0,16"
              }
            ]
          },
          {
            "Id": "17",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op250_1", // 读完标签上升沿能做就直接写壳体码
            "RfidRisingEdge": "DB50.1800.0",
            "RfidResponseEdge": "DB50.1800.1",
            "RisingEdge": "DB50.1800.2",
            "ResponseEdge": "DB50.1800.3",
            "StationAllow": "short,DB50.1802.0",
            "RfidLabel": "short,DB50.1804.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op250_1Beat",
                "TypeAndDb": "int,DB50.1806.0"
              }
            ]
          },
          {
            "Id": "18",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op250_2",
            "RfidRisingEdge": "DB50.1900.0",
            "RfidResponseEdge": "DB50.1900.1",
            "RisingEdge": "DB50.1900.2",
            "ResponseEdge": "DB50.1900.3",
            "StationAllow": "short,DB50.1902.0",
            "RfidLabel": "short,DB50.1904.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op250_2Result",
                "TypeAndDb": "short,DB50.1906.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op250_2Beat",
                "TypeAndDb": "int,DB50.1908.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.1912.0,16"
              }
            ]
          },
          {
            "Id": "19",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op260",
            "RfidRisingEdge": "DB50.2000.0",
            "RfidResponseEdge": "DB50.2000.1",
            "RisingEdge": "DB50.2000.2",
            "ResponseEdge": "DB50.2000.3",
            "StationAllow": "short,DB50.2002.0",
            "RfidLabel": "short,DB50.2004.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op260Beat",
                "TypeAndDb": "int,DB50.2006.0"
              }
            ]
          },
          {
            "Id": "20",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op270", // 执行器涂油组装
            "RfidRisingEdge": "DB50.2100.0",
            "RfidResponseEdge": "DB50.2100.1",
            "RisingEdge": "DB50.2100.2",
            "ResponseEdge": "DB50.2100.3",
            "StationAllow": "short,DB50.2102.0",
            "RfidLabel": "short,DB50.2104.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op270Beat",
                "TypeAndDb": "int,DB50.2106.0"
              }
            ]
          },
          {
            "Id": "21",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op280",
            "RfidRisingEdge": "DB50.2200.0",
            "RfidResponseEdge": "DB50.2200.1",
            "RisingEdge": "DB50.2200.2",
            "ResponseEdge": "DB50.2200.3",
            "StationAllow": "short,DB50.2202.0",
            "RfidLabel": "short,DB50.2204.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op280Beat",
                "TypeAndDb": "int,DB50.2206.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op280Torque",
                "TypeAndDb": "float,DB50.2210.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op280Angle",
                "TypeAndDb": "float,DB50.2214.0"
              },
              {
                "Id": "4",
                "SeqId": "1",
                "Sort": "4",
                "SqlColumnName": "Op280TorqueResult",
                "TypeAndDb": "short,DB50.2218.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op280Torque2",
                "TypeAndDb": "float,DB50.2220.0"
              },
              {
                "Id": "5",
                "SeqId": "1",
                "Sort": "5",
                "SqlColumnName": "Op280Angle2",
                "TypeAndDb": "float,DB50.2224.0"
              },
              {
                "Id": "6",
                "SeqId": "1",
                "Sort": "6",
                "SqlColumnName": "Op280TorqueResult2",
                "TypeAndDb": "short,DB50.2228.0"
              },
              {
                "Id": "7",
                "SeqId": "1",
                "Sort": "7",
                "SqlColumnName": "Op280Torque3",
                "TypeAndDb": "float,DB50.2230.0"
              },
              {
                "Id": "8",
                "SeqId": "1",
                "Sort": "8",
                "SqlColumnName": "Op280Angle3",
                "TypeAndDb": "float,DB50.2234.0"
              },
              {
                "Id": "9",
                "SeqId": "1",
                "Sort": "9",
                "SqlColumnName": "Op280TorqueResult3",
                "TypeAndDb": "short,DB50.2238.0"
              },
              {
                "Id": "10",
                "SeqId": "1",
                "Sort": "10",
                "SqlColumnName": "ShellCode", // 将数据放于壳体上
                "TypeAndDb": "string,DB50.2240.0,18"
              }
            ],
            "WriteData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.2240.0",
                "Value": "2023110800010001"
              }
            ]
          },
          {
            "Id": "22",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op290_1", // 读完标签上升沿能做就直接写壳体码，string,DB50.1610.0
            "RfidRisingEdge": "DB50.2300.0",
            "RfidResponseEdge": "DB50.2300.1",
            "RisingEdge": "DB50.2300.2",
            "ResponseEdge": "DB50.2300.3",
            "StationAllow": "short,DB50.2302.0",
            "RfidLabel": "short,DB50.2304.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op290_1Beat",
                "TypeAndDb": "int,DB50.2306.0"
              }
            ]
          },
          {
            "Id": "23",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op290_2", // 读完标签上升沿能做就直接写壳体码，string,DB50.1610.0
            "RfidRisingEdge": "DB50.2400.0",
            "RfidResponseEdge": "DB50.2400.1",
            "RisingEdge": "DB50.2400.2",
            "ResponseEdge": "DB50.2400.3",
            "StationAllow": "short,DB50.2402.0",
            "RfidLabel": "short,DB50.2404.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op290_2Result",
                "TypeAndDb": "short,DB50.2406.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op290_2Beat",
                "TypeAndDb": "int,DB50.2408.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.2412.0,16"
              }
            ]
          },
          {
            "Id": "24",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op300_1", // 读完标签上升沿能做就直接写壳体码，string,DB50.1610.0
            "RfidRisingEdge": "DB50.2500.0",
            "RfidResponseEdge": "DB50.2500.1",
            "RisingEdge": "DB50.2500.2",
            "ResponseEdge": "DB50.2500.3",
            "StationAllow": "short,DB50.2502.0",
            "RfidLabel": "short,DB50.2504.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op300_1Beat",
                "TypeAndDb": "int,DB50.2506.0"
              }
            ]
          },
          {
            "Id": "25",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op300_2",
            "RfidRisingEdge": "DB50.2600.0",
            "RfidResponseEdge": "DB50.2600.1",
            "RisingEdge": "DB50.2600.2",
            "ResponseEdge": "DB50.2600.3",
            "StationAllow": "short,DB50.2602.0",
            "RfidLabel": "short,DB50.2604.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op300_2Result",
                "TypeAndDb": "short,DB50.2606.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op300_2Beat",
                "TypeAndDb": "int,DB50.2608.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.2612.0,16"
              }
            ]
          },
          {
            "Id": "26",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op310_1", // 屏蔽
            "RfidRisingEdge": "DB50.2700.0",
            "RfidResponseEdge": "DB50.2700.1",
            "RisingEdge": "DB50.2700.2",
            "ResponseEdge": "DB50.2700.3",
            "StationAllow": "short,DB50.2702.0",
            "RfidLabel": "short,DB50.2704.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op310_1Beat",
                "TypeAndDb": "int,DB50.2706.0"
              }
            ]
          },
          {
            "Id": "27",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op310_2", //屏蔽
            "RfidRisingEdge": "DB50.2800.0",
            "RfidResponseEdge": "DB50.2800.1",
            "RisingEdge": "DB50.2800.2",
            "ResponseEdge": "DB50.2800.3",
            "StationAllow": "short,DB50.2802.0",
            "RfidLabel": "short,DB50.2804.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op310_2Beat",
                "TypeAndDb": "int,DB50.2806.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.2810.0,16"
              }
            ]
          },
          {
            "Id": "28",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op320", //螺柱组装
            "RfidRisingEdge": "DB50.2900.0",
            "RfidResponseEdge": "DB50.2900.1",
            "RisingEdge": "DB50.2900.2",
            "ResponseEdge": "DB50.2900.3",
            "StationAllow": "short,DB50.2902.0",
            "RfidLabel": "short,DB50.2904.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op320Beat",
                "TypeAndDb": "int,DB50.2906.0"
              },
              {
                "Id": "2",
                "SeqId": "1",
                "Sort": "2",
                "SqlColumnName": "Op320Torque",
                "TypeAndDb": "float,DB50.2910.0"
              },
              {
                "Id": "3",
                "SeqId": "1",
                "Sort": "3",
                "SqlColumnName": "Op320Angle",
                "TypeAndDb": "float,DB50.2914.0"
              },
              {
                "Id": "4",
                "SeqId": "1",
                "Sort": "4",
                "SqlColumnName": "Op320TorqueResult",
                "TypeAndDb": "short,DB50.2918.0"
              },
              {
                "Id": "5",
                "SeqId": "1",
                "Sort": "5",
                "SqlColumnName": "ShellCode",
                "TypeAndDb": "string,DB50.2920.0,16"
              }
            ]
          },
          {
            "Id": "29",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op330", // 托盘上升沿到了，tcpip 发数据给贴标机
            "RfidRisingEdge": "DB50.3000.0",
            "RfidResponseEdge": "DB50.3000.1",
            "RisingEdge": "DB50.3000.2",
            "ResponseEdge": "DB50.3000.3",
            "StationAllow": "short,DB50.3002.0",
            "RfidLabel": "short,DB50.3004.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op330Beat",
                "TypeAndDb": "int,DB50.3006.0"
              }
            ]
          },
          {
            "Id": "30",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op340",
            "RfidRisingEdge": "DB50.3100.0",
            "RfidResponseEdge": "DB50.3100.1",
            "RisingEdge": "DB50.3100.2",
            "ResponseEdge": "DB50.3100.3",
            "StationAllow": "short,DB50.3102.0",
            "RfidLabel": "short,DB50.3104.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op340Beat",
                "TypeAndDb": "int,DB50.3106.0"
              }
            ]
          },
          {
            "Id": "31",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op350", // 人工下料，rfid 壳体码解绑
            "RfidRisingEdge": "DB50.3200.0",
            "RfidResponseEdge": "DB50.3200.1",
            "RisingEdge": "DB50.3200.2",
            "ResponseEdge": "DB50.3200.3",
            "StationAllow": "short,DB50.3202.0",
            "RfidLabel": "short,DB50.3204.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op350Beat",
                "TypeAndDb": "int,DB50.3206.0"
              }
            ]
          },
          {
            "Id": "32",
            "DeviceId": "2",
            "DeviceName": "环形2线",
            "SeqName": "Op360",
            "RfidRisingEdge": "DB50.3300.0",
            "RfidResponseEdge": "DB50.3300.1",
            "RisingEdge": "DB50.3300.2",
            "ResponseEdge": "DB50.3300.3",
            "StationAllow": "short,DB50.3302.0",
            "RfidLabel": "short,DB50.3304.0",
            "SqlOperate": "Update",
            "ReadData": [
              {
                "Id": "1",
                "SeqId": "1",
                "Sort": "1",
                "SqlColumnName": "Op360Beat",
                "TypeAndDb": "int,DB50.3306.0"
              }
            ]
          }
        ]
      }
    ]
  }
}
export default data