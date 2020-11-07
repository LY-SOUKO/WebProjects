﻿<%@ Page Title="登录" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebProject.Common.Longin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/Login.css" rel="stylesheet" />
      <style type="text/css">
      .souko1 {
          position: fixed;
          text-align: center;
          top: 682px;
          width: 100%;
          height: auto;
          display: flex;
          justify-content: center;
      }
      .copyrights {
          height: 100px;
          
      }
          .copyrights a {
              float: left;
              margin-right: 40px;
              margin-left:40px;
          }
          .tips-text {
          color:#ff0000;
          }
  </style>
</head>
<body>
    <script src="/JS/jquery1.10.2.min.js"></script>
    <script src="/JS/threer63.min.js"></script>
    <script src="js/Login.js"></script>
    <form id="form1" runat="server">
            <asp:HiddenField ID="hidCore" runat="server" />
                <div class="main">
        <div class="login">
            <div class="log-con">
                <span>登录</span>
                <input type="text" class="name" placeholder="请输入用户名" />
                <input type="text" class="password" placeholder="请输入密码" />
                <input type="text" class="code captcha-code" placeholder="请输入验证码"/>
                <input type="button" id="code" class="captcha-code" onclick="change();"/>
                <a id="btnOk">立即登录</a>
                <p class="tips-text"></p>
            </div>
        </div>
    <div class="souko1">
        <div class="copyrights">
            <!--<a>
                <img src="img/客户信息.png" /><p>客户信息</p>
            </a>
            <a>
                <img src="img/客户信息.png" /><p>客户信息</p>
            </a>
            <a>
                <img src="img/客户信息.png" /><p>客户信息</p>
            </a>
            <a>
                <img src="img/客户信息.png" /><p>客户信息</p>
            </a>
            <a>
                <img src="img/客户信息.png" /><p>客户信息</p>
            </a>-->
        </div>
    </div>
    </div>
    </form>
    <script>

        var SEPARATION = 100, AMOUNTX = 60, AMOUNTY = 40;
        var container;
        var camera, scene, renderer;
        var particles, particle, count = 0;
        var mouseX = 0, mouseY = 0;
        var windowHalfX = window.innerWidth / 2;
        var windowHalfY = window.innerHeight / 2;

        $(function () {
            init();		//初始化
            animate();	//动画效果
            change();	//验证码
        });

        //初始化
        function init() {

            container = document.createElement('div');	//创建容器
            document.body.appendChild(container);			//将容器添加到页面上
            camera = new THREE.PerspectiveCamera(120, window.innerWidth / window.innerHeight, 1, 1500);		//创建透视相机设置相机角度大小等
            camera.position.set(0, 450, 2000);		//设置相机位置

            scene = new THREE.Scene();			//创建场景
            particles = new Array();

            var PI2 = Math.PI * 2;
            //设置粒子的大小，颜色位置等
            var material = new THREE.ParticleCanvasMaterial({
                color: 0x0f96ff,
                vertexColors: true,
                size: 4,
                program: function (context) {
                    context.beginPath();
                    context.arc(0, 0, 0.01, 0, PI2, true);	//画一个圆形。此处可修改大小。
                    context.fill();
                }
            });
            //设置长条粒子的大小颜色长度等
            var materialY = new THREE.ParticleCanvasMaterial({
                color: 0xffffff,
                vertexColors: true,
                size: 1,
                program: function (context) {

                    context.beginPath();
                    //绘制渐变色的矩形
                    var lGrd = context.createLinearGradient(-0.008, 0.25, 0.016, -0.25);
                    lGrd.addColorStop(0, '#16eff7');
                    lGrd.addColorStop(1, '#0090ff');
                    context.fillStyle = lGrd;
                    context.fillRect(-0.008, 0.25, 0.016, -0.25);  //注意此处的坐标大小
                    //绘制底部和顶部圆圈
                    context.fillStyle = "#0090ff";
                    context.arc(0, 0, 0.008, 0, PI2, true);    //绘制底部圆圈
                    context.fillStyle = "#16eff7";
                    context.arc(0, 0.25, 0.008, 0, PI2, true);    //绘制顶部圆圈
                    context.fill();
                    context.closePath();
                    //绘制顶部渐变色光圈
                    var rGrd = context.createRadialGradient(0, 0.25, 0, 0, 0.25, 0.025);
                    rGrd.addColorStop(0, 'transparent');
                    rGrd.addColorStop(1, '#16eff7');
                    context.fillStyle = rGrd;
                    context.arc(0, 0.25, 0.025, 0, PI2, true);    //绘制一个圆圈
                    context.fill();

                }
            });

            //循环判断创建随机数选择创建粒子或者粒子条
            var i = 0;
            for (var ix = 0; ix < AMOUNTX; ix++) {
                for (var iy = 0; iy < AMOUNTY; iy++) {
                    var num = Math.random() - 0.1;
                    if (num > 0) {
                        particle = particles[i++] = new THREE.Particle(material);
                        console.log("material")
                    }
                    else {
                        particle = particles[i++] = new THREE.Particle(materialY);
                        console.log("materialY")
                    }
                    //particle = particles[ i ++ ] = new THREE.Particle( material );
                    particle.position.x = ix * SEPARATION - ((AMOUNTX * SEPARATION) / 2);
                    particle.position.z = iy * SEPARATION - ((AMOUNTY * SEPARATION) / 2);
                    scene.add(particle);
                }
            }

            renderer = new THREE.CanvasRenderer();
            renderer.setSize(window.innerWidth, window.innerHeight);
            container.appendChild(renderer.domElement);
            //document.addEventListener( 'mousemove', onDocumentMouseMove, false );
            //document.addEventListener( 'touchstart', onDocumentTouchStart, false );
            //document.addEventListener( 'touchmove', onDocumentTouchMove, false );
            window.addEventListener('resize', onWindowResize, false);
        }

        //浏览器大小改变时重新渲染
        function onWindowResize() {
            windowHalfX = window.innerWidth / 2;
            windowHalfY = window.innerHeight / 2;
            camera.aspect = window.innerWidth / window.innerHeight;
            camera.updateProjectionMatrix();
            renderer.setSize(window.innerWidth, window.innerHeight);
        }

        function animate() {
            requestAnimationFrame(animate);
            render();
        }

        //将相机和场景渲染到页面上
        function render() {
            var i = 0;
            //更新粒子的位置和大小
            for (var ix = 0; ix < AMOUNTX; ix++) {
                for (var iy = 0; iy < AMOUNTY; iy++) {
                    particle = particles[i++];
                    //更新粒子位置
                    particle.position.y = (Math.sin((ix + count) * 0.3) * 50) + (Math.sin((iy + count) * 0.5) * 50);
                    //更新粒子大小
                    particle.scale.x = particle.scale.y = particle.scale.z = ((Math.sin((ix + count) * 0.3) + 1) * 4 + (Math.sin((iy + count) * 0.5) + 1) * 4) * 50;	//正常情况下再放大100倍*1200
                }
            }

            renderer.render(scene, camera);
            count += 0.1;
        }

        //验证码
        function change() {
            code = $("#code");
            // 验证码组成库
            var arrays = new Array(
                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'
            );
            codes = '';// 重新初始化验证码
            for (var i = 0; i < 4; i++) {
                // 随机获取一个数组的下标
                var r = parseInt(Math.random() * arrays.length);
                codes += arrays[r];
            }
            // 验证码添加到input里
            code.val(codes);
        }
    </script>

</body>
</html>
