<template>
    <div class="backgroundColor">
        <!-- <img src="@/assets/imgs/SteelBall.png" alt="" v-if="showData.SteelBall == 'N' || !showData.SteelBall" class="absent">
        <img src="@/assets/imgs/SteelBall-active.png" alt="" v-else class="exist">
        <img src="@/assets/imgs/PlugCap.png" alt="" v-if="showData.PlugCap == 'N'" class="absent">
        <img src="@/assets/imgs/PlugCap-active.png" alt="" v-else class="exist">
        <img src="@/assets/imgs/Nut.png" alt="" v-if="showData.Nut == 'N'" class="absent">
        <img src="@/assets/imgs/Nut-active.png" alt="" v-else class="exist">
        <img src="@/assets/imgs/Spring.png" alt="" v-if="showData.Spring == 'N'" class="absent">
        <img src="@/assets/imgs/Spring-active.png" alt="" v-else class="exist"> 
        <img src="@/assets/imgs/Bearing.png" alt="" v-if="showData.Bearing == 'N'" class="absent">
        <img src="@/assets/imgs/Bearing-active.png" alt="" v-else class="exist">
        <img src="@/assets/imgs/Case.png" alt="" v-if="showData.Case == 'N'" class="absent">
        <img src="@/assets/imgs/Case-active.png" alt="" v-else class="exist"> -->
        <template v-for="(value, key) in showData">
            <img :src="require('@/assets/imgs/'+ key +'-active.png')" alt="" v-if="showData[key] == 'Y'" class="exist">
            <img :src="require('@/assets/imgs/'+ key +'.png')" alt="" v-else class="absent">
        </template>
    </div>
</template>

<script>
export default {
    data() {
        return {
            showData: {
                SteelBall: 'N',
                PlugCap: 'N',
                Nut: 'N',
                Spring: 'N',
                Bearing: 'N',
                Case: 'N'
            }
        }
    },
    methods: {
        changeData () {
            this.showData.SteelBall = 'Y'
        }
    },
    mounted() {
        // this.changeData()
    }
}
</script>

<style lang="less">
.backgroundColor {
    // width: calc(100%);
    /* height: calc(100vh - 700px); */
    // height: 300px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: #eee;
}
// .backgroundColor img {
//     margin: 0px 10px;
//     width: 15%;
//     height: 200px;
// }
.exist {
    border: 5px solid green;
    box-sizing: border-box;
}
.absent {
    border: 5px solid red;
    box-sizing: border-box;
}
.rfid-container {
    display: flex;
    .view-container {
        width: calc(100% - 230px);
    }
    .backgroundColor {
        width: 230px;
        flex: 0 0 auto;
        flex-wrap: wrap;
        img {
            margin: 0px 10px;
            width: 98%;
            height: 120px;
            object-fit: cover;
        }
    }
}
@media screen and (max-height: 816px) {
.rfid-container {
    .view-container {
        width: calc(100% - 150px);
    }
    .backgroundColor {
        width: 150px;
        img {
            width: 98%;
            height: 80px;
        }
    }
}
}
</style>