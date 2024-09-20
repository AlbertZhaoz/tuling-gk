<template>
  <div class="bg">
    <div class="content">
      <div class="l-left">
        <div class="desc">
          <div class="title">
            工厂数字化系统
            <span style="
                font-size: 12px;
                background: #46c706;
                border-radius: 24px;
                padding: 4px 9px;
                border: 1px solid;
                margin-left: 3px;
              ">V0.0.1</span>
          </div>
          <p>开发人员：AlbertZhao</p>
          <p>前端技术: Vue、Promise、Vuex、IView、El-UI...</p>
          <p>后端技术：.NET Core、EF Core、Dapper、Redis...</p>
          <p>演示账号：账号：test 密码：test123</p>
          <!-- <p>本地账号：admin &nbsp; &nbsp; &nbsp; 密码:123456</p> -->
          <p>系统维护请联系开发人员：szdxzhy@outlook.com</p>
          <div style="margin-top: 30px" class="link">
            <a href="https://github.com/AlbertZhaoz" target="_blank">
              <span>GitHub</span>
            </a>
            <a href="https://github.com/AlbertZhaoz" target="_blank">
              <span>Gitee</span>
            </a>
            <a href="http://localhost:5000/run:albert?reportName=%E5%A4%A7%E5%B1%8F/yt043_%E7%9C%8B%E6%9D%BF.cr" target="_blank">
              <span>数字大屏</span>
            </a>
            <a href="https://www.yuque.com/albertzhao/dotnet" target="_blank">
              <span>系统文档</span>
            </a>
          </div>
        </div>
      </div>
      <div class="login">
        <div class="login-contianer">
          <div class="login-form">
            <h2>账号登录</h2>
            <div class="v-tag">V0.0.1</div>
            <!-- 用户登录 -->
            <div class="form-user" @keypress="loginPress">
              <div class="item">
                <div class="f-text">
                  <label>用户名：</label>
                </div>
                <div class="f-input">
                  <input type="text" v-focus v-model="userInfo.userName" placeholder="输入用户" />
                </div>
              </div>
              <div class="item">
                <div class="f-text">
                  <label>密&nbsp;&nbsp;&nbsp;码：</label>
                </div>
                <div class="f-input">
                  <el-input show-password type="password" v-focus v-model="userInfo.password" placeholder="输入密码"></el-input>
                </div>
              </div>
            </div>
            <div class="loging-btn">
              <el-button size="large" :loading="loading" type="primary" @click="login" long>
                <span v-if="!loading">登录/注册</span>
                <span v-else>正在登录...</span>
              </el-button>
            </div>
            <div class="app-link">
              <p>系统维护请联系开发人员:szdxzhy@outlook.com</p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="l-bg"></div>
    <div class="r-bg"></div>

    <div class="login-footer">
      <a style="text-decoration: none" href="https://space.bilibili.com/188860609" target="_blank">工厂数字化系统</a>
    </div>
  </div>
</template>
<script>
import {
  defineComponent,
  ref,
  reactive,
  toRefs,
  getCurrentInstance,
} from "vue";
import { useRouter, useRoute } from "vue-router";
import store from "../store/index";
import http from "@/../src/api/http.js";
export default defineComponent({
  setup(props, context) {
    const loading = ref(false);
    const codeImgSrc = ref("");
    const userInfo = reactive({
      userName: "",
      password: "",
      UUID: undefined,
    });

    const getVierificationCode = () => {
      http.get("/api/User/getVierificationCode").then((x) => {
        codeImgSrc.value = "data:image/png;base64," + x.img;
        userInfo.UUID = x.uuid;
      });
    };
    getVierificationCode();

    let appContext = getCurrentInstance().appContext;
    let $message = appContext.config.globalProperties.$message;
    let router = useRouter();

    const login = () => {
      if (!userInfo.userName) return $message.error("请输入用户名");
      if (!userInfo.password) return $message.error("请输入密码");
      loading.value = true;
      http.post("/api/user/login", userInfo, "正在登录....").then((result) => {
        if (!result.status) {
          loading.value = false;
          getVierificationCode();
          return $message.error(result.message);
        }
        $message.success("登录成功,正在跳转!");
        store.commit("setUserInfo", result.data);
        router.push({ path: "/" });
      });
    };
    const loginPress = (e) => {
      if (e.keyCode == 13) {
        login();
      }
    };
    const openUrl = (url) => {
      window.open(url, "_blank");
    };
    return {
      loading,
      codeImgSrc,
      getVierificationCode,
      login,
      userInfo,
      loginPress,
      openUrl,
    };
  },
  directives: {
    focus: {
      inserted: function (el) {
        el.focus();
      },
    },
  },
});
</script>

<style lang="less" scoped>
.bg {
  display: flex;
  overflow: hidden;
  position: relative;
  height: 100%;
  width: 100%;
  background-image: linear-gradient(135deg, #24aded 10%, #40b3e8);
}

.login {
  flex: 1;
}
.loging-btn {
  button {
    width: 100%;
    font-size: 14px !important;
    letter-spacing: 2px;
  }
}
.content {
  display: flex;
  z-index: 99;
  position: relative;
  width: 860px;
  left: 0;
  right: 0;

  margin: 0 auto;
  transform: translateY(-50%);
  // background: #dedede40;
  top: 50%;
  height: 400px;
  border-radius: 10px;
  .l-left {
    border-top-left-radius: 5px;
    border-bottom-left-radius: 5px;
    width: 400px;
    // background-image: linear-gradient(135deg, #0d82ff 10%, #0cd7bd);
    // border: 1px solid #5c87ff;
  }
}

.desc {
  text-align: left;
  width: 450px;
  padding: 10px 30px;
  box-sizing: border-box;
  height: 100%;
}

.desc p {
  font-size: 15px;
  color: white;
  line-height: 30px;
}

.desc p:before {
  top: -1px;
  content: "o";
  position: relative;
  margin-right: 7px;
}

.title {
  z-index: 999;
  font-size: 45px;
  font-weight: bold;
  color: white;
}

.l-bg {
  height: 1200px;
  width: 1200px;
  border-radius: 50%;
  background: #2cecff;
  position: absolute;
  top: -700px;
  left: -700px;
  background-image: linear-gradient(135deg, #00a7f5 10%, #0cb3ff);
}

.r-bg {
  height: 2000px;
  width: 2000px;
  border-radius: 50%;
  background: #2cecff;
  position: absolute;
  top: -1500px;
  right: -900px;
  background-image: linear-gradient(135deg, #42c2ff 10%, #1da1dc);
}
</style>

<style lang="less" scoped>
.form-user {
  margin: 25px 0;

  .item {
    display: flex;
    padding-bottom: 5px;
    border-bottom: 1px solid #eee;
    margin-bottom: 30px;
    display: flex;
    .f-text {
      color: #484848;
      font-weight: 400;
      width: 110px;
      font-size: 16px;
      text-align: left;
      i {
        position: relative;
        top: -1px;
        right: 5px;
      }
    }
    .f-input {
      border: 0px;
      flex: 1;
    }
    .f-input:deep(.el-input__wrapper) {
      background-color: #fff;
      padding: 0px;
      box-shadow: 0 0 0 0;
    }
    .code {
      position: relative;
      cursor: pointer;
      top: -5px;
      width: 74px;
      border: 1px solid #fdfdfd;
      border-radius: 2px;
      height: 35px;
      margin-left: 10px;
    }
  }
}
input:-webkit-autofill {
  box-shadow: 0 0 0px 1000px white inset;
}
.login-contianer {
  margin: 0 40px;
  .login-form {
    position: relative;
    overflow: hidden;
    // margin-top: 25px;
    border-top-right-radius: 5px;
    border-bottom-right-radius: 5px;
    padding: 10px 30px 40px 30px;
    width: 400px;
    min-height: 340px;
    background: white;
    height: 400px;
    box-shadow: 2px 5px 18px #6453534a;
    h2 {
      font-weight: 500;
      padding: 10px 0px;
      text-align: left;
      margin-top: 15px;
    }
    .v-tag {
      top: -23px;
      text-align: center;
      position: absolute;
      right: -43px;
      line-height: 49px;
      top: -17px;
      padding-left: 21px;
      font-size: 12px;
      width: 158px;
      background: #3a8ee6;
      padding-top: 25px;
      color: white;
      -webkit-transform: rotate(40deg);
      letter-spacing: 2px;
    }
  }
}

.loging-btn {
  margin-top: 20px;
}
.action {
  text-align: right;
  margin-top: 20px;
  font-size: 12px;
  color: #9c9c9c;
  cursor: pointer;
  a {
    margin-left: 20px;
  }
}
.login-footer {
  cursor: pointer;
  padding: 10px;
  text-align: center;
  font-size: 14px;
  position: absolute;
  width: 100%;
  bottom: 0px;
  background: #06a3ea;
  border-top: 1px solid #e2e2e2;
  i {
    position: relative;
    top: -2px;
    margin-right: 5px;
  }
  a {
    margin-left: 30px;
    color: #f9ebd0;
  }
}
@media screen and (max-width: 600px) {
  .desc {
    display: none;
  }
  .bg {
    background-image: none;
  }
  .login-form {
    box-shadow: none !important;
  }
  .login-form {
    width: 100% !important;
  }
  .login-footer,
  .r-bg,
  .l-bg {
    display: none;
  }
  .l-left {
    display: none;
  }
  .c-bg-item {
    background: none !important;
  }
}
.link a {
  text-decoration: none;

  color: #ffff;
  border: 1px solid #ffff;
  width: 80px;
  margin-right: 5px;
  display: inline-block;
  margin-bottom: 0;
  font-weight: 400;
  text-align: center;
  touch-action: manipulation;
  cursor: pointer;
  background-image: none;

  white-space: nowrap;
  user-select: none;
  padding: 5px 15px 6px;
  font-size: 12px;
  border-radius: 32px;
}
</style>
<style scoped>
input:-webkit-autofill {
  -webkit-box-shadow: 0 0 0px 1000px white inset !important;
}
input {
  background: white;
  display: block;
  box-sizing: border-box;
  width: 100%;
  min-width: 0;
  margin: 0;
  padding: 0;
  color: #323233;
  line-height: inherit;
  text-align: left;
  border: 0;
  outline: none;
  font-size: 16px;
  line-height: 20px;
}
</style>
<style lang="less" scoped>
.c-bg {
  position: absolute;
  width: 100%;
  height: 200px;

  .c-bg-item {
    width: 25%;
    background: #00a7f5;
    height: 200px;
  }
}
.app-link {
  text-align: center;
  padding-top: 21px;
  font-size: 14px;
  a {
    position: relative;
    cursor: pointer;
    width: 70px;
    color: #1483f6;
    margin: 20px 20px 0 0;
  }
  img {
    display: none;
  }
  a:hover {
    img {
      display: block;
      position: absolute;
      z-index: 999999999;
      top: -130px;
      width: 120px;
      left: -22px;
      border: 1px solid #b1b1b1;
    }
  }
}
</style>
