<template>
  <div class="read-json-container">
    <div class="left">
      <div class="device-header">
        环线列表
      </div>
      <div class="device-list">
        <el-scrollbar style="height: 100%">
          <div :class="deviceIndex === index ? 'device-item active' : 'device-item'" v-for="(item, index) in deviceList" :key="index">
            <div class="device-box">
              <div class="device-box-left" @click="chooseDeviceList(index)">
                <div class="device-name">{{item.Name}}</div>
                <div class="device-add">{{item.IpAddress}}</div>
              </div>
              <div class="device-box-right" @click="openState[index] = !openState[index]">
                <i class="el-icon-arrow-down" v-show="!openState[index]"></i>
                <i class="el-icon-arrow-up" v-show="openState[index]"></i>
              </div>
            </div>
            <div class="station" v-show="openState[index]">
              <div :class="'station-name'" v-for="(station, stationItemIndex) in item.StationSeqs" :key="station.Id"  @click="chooseDeviceItem(index, stationItemIndex, station.Id)">{{station.SeqName}}</div>
            </div>
          </div>
          <div class="device-item device-add-button">
            <!-- 新建环线 -->
            <el-button type="primary" @click="addCircleLine"><i class="el-icon-plus"></i>新建环线</el-button>
          </div>
        </el-scrollbar>
      </div>
    </div>
    <div class="main">
      <div class="main-header">
        <div class="main-title">详情</div>
        <div class="main-button">
          <!-- <el-button type="primary" @click="uploadJSON">导入JSON文件</el-button> -->
          <div class="upload-file" v-show="false">
            导入JSON文件
            <input type="file" id="upload" @change="uploadFile" />
          </div>
          <el-button type="primary" @click="clickUpload">导入JSON文件</el-button>
          
          <el-button type="primary" @click="saveJSON">导出JSON文件</el-button>
        </div>
      </div>
      <div class="main-show" v-if="deviceList.length" v-loading="loading">
        <el-scrollbar ref="scrollbarRef" style="height: 100%">
          <!-- 环线详情 -->
          <div class="station-title mt20">
            <div class="">{{deviceList[deviceIndex].Name}}</div>
            <div class="">
              <el-button type="primary" plain @click="deleteCircleLine()">
                <i class="el-icon-delete"></i> 删除此环线
              </el-button>
              <el-button type="primary" plain @click="addStation()">
                <i class="el-icon-plus"></i> 新建空白工站
              </el-button>
            </div>
          </div>
          <div class="circle-line form-list">
            <template v-for="(circleValue, circleKey) in deviceList[deviceIndex]">
              <div class="circle-line-item form-item form-item-input" v-if="circleKey !== 'StationSeqs'">
                <div class="label">{{circleKey}}</div>
                <div class="value">
                  <!-- <el-select v-model="deviceList[deviceIndex][circleKey]" v-if="circleKey === 'StationSeqs'">
                    <el-option label="true" value="true"/>
                    <el-option label="false" value="false"/>

                  </el-select> -->
                  <el-input
                    v-model="deviceList[deviceIndex][circleKey]"
                    :disabled="circleKey === 'Id'"
                  />
                </div>
              </div>
            </template>
          </div>
          <div class="station-title">
            <div class="mt20">StationSeqs:</div>
            <div class="">
              <!-- <el-button type="primary" plain @click="copyStation(stationIndex)">复制到最后</el-button> -->
            </div>
          </div>
          <div v-for="(stationItem, stationIndex) in deviceList[deviceIndex].StationSeqs" :key="stationItem.Id" class="station-item" :id="'station' + stationItem.Id">
            
            <div class="station-title">
              <div class="">{{stationItem.SeqName}}</div>
              <div class="">
                <el-button type="primary" plain @click="deleteStation(stationIndex)">
                  <i class="el-icon-delete"></i> 删除此站
                </el-button>
                <el-button type="primary" plain @click="copyStation(stationIndex)">
                  <i class="el-icon-plus"></i> 复制到最后
                </el-button>
              </div>
            </div>
            <div class="form-list">
              <template v-for="(stationValue, stationKey) in stationItem">
                <div :class="(stationKey === 'ReadData' || stationKey === 'WriteData') ? 'form-item form-item-table' : 'form-item form-item-input'" v-if="stationKey === 'ReadData' || stationKey === 'WriteData'">
                  <EditTable :key="stationKey + deviceIndex" :type="stationKey" :dataList="stationItem[stationKey]" :stationIndex="stationIndex" :stationId="stationItem['Id']" @editReadData="editReadData" />
                </div>
                <div :class="(stationKey === 'ReadData' || stationKey === 'WriteData') ? 'form-item form-item-table' : 'form-item form-item-input'" v-if="stationKey !== 'ReadData' && stationKey !== 'WriteData'">
                  <div class="label">{{stationKey}}</div>
                  <div class="value">
                    <el-select v-model="stationItem[stationKey]" v-if="stationKey === 'SqlOperate'">
                      <el-option
                        v-for="option in SqlOperateList"
                        :label="option"
                        :value="option"
                      />
                    </el-select>
                    <el-input
                      v-else
                      v-model="stationItem[stationKey]"
                      :disabled="stationKey === 'Id'"
                    />
                  </div>
                </div>
                
              </template>
            </div>
            <el-divider class="divider" />
          </div>
        </el-scrollbar>        
      </div>
    </div>
  </div>
</template>
<script setup>
import { onMounted, ref, reactive, nextTick } from 'vue'
import dataJson from './DeviceCollections.js'
import EditTable from './EditTable.vue'
let deviceList = ref([])
let openState = ref([])
const stationSeqs = ref([])
const SqlOperateList = ref([
  'None', 'Insert', 'Update', 'Ignore'
])
const scrollbarRef = ref(null)
let loading = ref(false)
let deviceIndex = ref(0)
const chooseDeviceList = (index) => {
  deviceIndex.value = index
  scrollbarRef.value.setScrollTop(0)
  // stationSeqs.value = deviceList.value[deviceIndex.value].StationSeqs
}
const chooseDeviceItem = (index, stationItemIndex, id) => {
  deviceIndex.value = index
  // chooseDeviceList(index)
  nextTick(() => {
    let dom = document.getElementById('station' + id)
    // console.log(dom.offsetTop)
    let top = dom.offsetTop || 0
    scrollbarRef.value.setScrollTop(top)
  })
}

const addStation = () => {
  let currentLength = deviceList.value[deviceIndex.value].StationSeqs.length
  let lastId = currentLength ? deviceList.value[deviceIndex.value].StationSeqs[currentLength - 1].Id : '0'
  // console.log(lastId)
  let newId = (Number(lastId) + 1).toString()
  let newData = {
    Id: newId,
    DeviceId: deviceList.value[deviceIndex.value].Id,
    DeviceName: deviceList.value[deviceIndex.value].Name,
    SeqName: `Op${newId}0`,
    RfidRisingEdge: '',
    RfidResponseEdge: '',
    RisingEdge: '',
    ResponseEdge: '',
    StationAllow: '',
    RfidLabel: '',
    SqlOperate: '',
    ReadData: []
  }
  deviceList.value[deviceIndex.value].StationSeqs.push(newData)
}
const copyStation = (stationIndex) => {
  let newData = JSON.parse(JSON.stringify(deviceList.value[deviceIndex.value].StationSeqs[stationIndex]))
  // console.log(newData)
  let oldId = deviceList.value[deviceIndex.value].StationSeqs[stationIndex].Id.toString()
  let currentLength = deviceList.value[deviceIndex.value].StationSeqs.length
  let lastId = currentLength ? deviceList.value[deviceIndex.value].StationSeqs[currentLength - 1].Id : '0'
  // console.log(lastId)
  // let newId = (deviceList.value[deviceIndex.value].StationSeqs.length + 1).toString()
  let newId = (Number(lastId) + 1).toString()

  newData.Id = newId
  // console.log(oldId, newId)
  newData = replaceSomething(newData, oldId, newId)
  // console.log(replaceSomething(newData, oldId, newId))
  // str.replaceAll(stationIndex + '0', newId + '0')
  // newData.Id = (deviceList.value[deviceIndex.value].StationSeqs.length + 1).toString()
  deviceList.value[deviceIndex.value].StationSeqs.push(newData)
}
const deleteStation = (stationIndex) => {
  deviceList.value[deviceIndex.value].StationSeqs.splice(stationIndex, 1)
}
const deleteCircleLine = () => {
  deviceList.value.splice(deviceIndex.value, 1)
  openState.value.splice(deviceIndex.value, 1)
}
const addCircleLine = () => {
  let last = deviceList.value.length ? deviceList.value[deviceList.value.length - 1].Id : '0'
  let next = (Number(last) + 1).toString()
  let newCircle = {
    Id: next,
    Name: `环形${next}线`,
    IpAddress: '',
    Port: '102',
    ConnectTimeOut: '3000',
    ReceiveTimeOut: '3000',
    SetHeartAddress: 'DB50.0.0',
    ProductType: 'short,DB50.2.0',
    StationSeqs: []
  }
  deviceList.value.push(newCircle)
  openState.value.push(false)
}
const replaceSomething = (newData, oldId, newId) => {
  for (let key in newData) {
    // console.log(key, newData[key], typeof(newData[key]), typeof(newData[key]) == 'string')
    if (typeof(newData[key]) == 'string') {
      newData[key] = newData[key].replaceAll(oldId + '0', newId + '0')
    } else if (newData[key] instanceof Array) {
      // console.log(key, newData[key])
      newData[key].forEach(ele => {
        if (key === 'ReadData') {
          // console.log(ele, typeof(ele))
        }
        if (typeof(ele) == 'string') {
          ele = ele.replaceAll(oldId + '0', newId + '0')
        } else {
          ele = replaceSomething(ele, oldId, newId)
          // console.log(ele)
        }
      })
    }
  }
  return newData
}
const saveJSON = () => {
  let reTitle = 'DeviceCollections.json'
  let value = {
    DeviceCollections: {
      DeviceCollection: deviceList.value
    }
  }
  let dataStr = JSON.stringify(value)

    return isMSbrowser()
    ? new Promise(resolve => { // Edge、IE11
        let blob = new Blob([dataStr], { type: 'text/plain;charset=utf-8' })
        window.navigator.msSaveBlob(blob, reTitle)
        resolve()
    })
    : new Promise(resolve => { // Chrome、Firefox
        let a = document.createElement('a')
        a.href = 'data:text/json;charset=utf-8,' + dataStr
        a.download = reTitle
        a.click()
        resolve()
    })
}
const isMSbrowser = () => {
  const  userAgent = window.navigator.userAgent
  return userAgent.indexOf('Edge') !== -1 || userAgent.indexOf('Trident') !== -1
}
const uploadFile = (e) => {
  // console.log(e.target.files[0])
  let file = e.target.files[0]
  if (window.FileReader) {
    let render = new FileReader()
    render.readAsText(file)
    render.onloadend = (event) => {
      // console.log(event.target.result)
      let newJson = JSON.parse(event.target.result)
      deviceList.value = JSON.parse(JSON.stringify(newJson.DeviceCollections.DeviceCollection))
    }
  } else {
    console.log('浏览器暂不支持该功能')

  }
}
const editReadData = ({type, stationIndex, dataList}) => {
  // console.log(type, deviceIndex, stationIndex, dataList)
  deviceList.value[deviceIndex.value].StationSeqs[stationIndex][type] = dataList
}
const clickUpload = () => {
  document.getElementById('upload').click()
}
onMounted(() => {
  // console.log(dataJson.DeviceCollections.DeviceCollection)
  deviceList.value = JSON.parse(JSON.stringify(dataJson.DeviceCollections.DeviceCollection))
  deviceList.value.forEach((item) => {
    openState.value.push(false)
  })
})
</script>
<style lang="less" scoped>
.read-json-container {
  display: flex;
  height: calc(100vh - 100px);
  padding: 10px;
  box-sizing: border-box;
  background: #f7f7f7;
  // background: red;
  .left {
    width: 200px;
    // border: 1px solid #ccc;
    height: 100%;
    background: #fff;
    margin-right: 10px;
    .device-header {
      line-height: 40px;
      font-size: 15px;
      background: #66b1ff0f;
      font-weight: bold;
      padding: 6px 16px;
      border-bottom: 1px solid #eee;
    }
    .device-list {
      height: calc(100% - 53px);
      .device-add-button .el-button {
        width: 156px;
      }
      .device-item {
        // border: 1px solid #ccc;
        width: 100%;
        padding: 15px 0 10px 20px;
        box-sizing: border-box;
        color: #606266;
        .device-name {
          font-size: 16px;
          cursor: pointer;
        }
        .device-add {
          font-size: 14px;
        }
        .station {
          padding: 10px 0 10px 0;
          font-size: 14px;
          .station-name {
            padding: 8px 0 8px 30px;
            cursor: pointer;
          }
        }
      }
      .active {
        .device-name, .device-add {
          color: #409eff;
        }
      }
      .device-box {
        display: flex;
        justify-content: space-between;
        align-items: center;
        .device-box-right {
          margin-right: 15px;
        }
      }
    }
  }
  .main {
    background: #fff;
    width: calc(100% - 220px);
    height: 100%;
    .main-header {
      height: 53px;
      display: flex;
      padding: 6px 16px;
      border-bottom: 1px solid #eee;
      justify-content: space-between;
      background: #66b1ff0f;
      .main-title {
        line-height: 40px;
        font-size: 15px;
        font-weight: bold;
      }
      .main-button {
        display: flex;
        padding: 6px 0;
        .upload-file {
          position: relative;
          width: 112px;
          height: 32px;
          input[type='file'] {
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            appearance: none;
            background-color: none;
            border: none;
            color: white;
            font-size: 0px;
            // padding: 12px 14px;
          }
        }
      }
    }
    .main-show {
      height: calc(100% - 53px);
    }
    .divider {
      width: 96%;
      margin: 30px 2% 0;
      // margin: 0px 2% 30px;
      border-color: #2d8cf0;
    }
    .station-item {
      padding-top: 30px;
    }
    .station-title {
      padding-left: 2%;
      padding-right: 1%;
      display: flex;
      font-size: 18px;
      justify-content: space-between;
    }
    .form-list {
      display: flex;
      flex-wrap: wrap;        
    }
    .form-item {
      .el-select {
        width: 100%;
      }
    }
    .form-item-table {
      width: 96%;
      margin: 0 2% 0 2%;
      flex: 0 0 auto;
    }
    .form-item-input {
      margin: 10px 0;
      display: flex;
      width: 33%;
      align-items: center;
      flex: 0 0 auto;
      .label {
        width: 160px;
        color: #606266;
        text-align: right;
        padding-right: 10px;
        flex: 0 0 auto;
      }
      .value {
        flex: auto;
      }
    }
  }
  .mt20 {
    margin-top: 20px;
  }
}
</style>
