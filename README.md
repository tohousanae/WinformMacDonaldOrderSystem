# 模擬麥當勞訂餐
## 功能

客人端功能：
```bash
- 會員登入
- 會員註冊
- 修改會員資料
- 瀏覽商品(可選圖片模式或文字模式)
- 加入購物車、送出訂單(結帳)、輸出明細
```

商家端功能：
```bash
- 權限： 100~1000
- 職位： 店員
- 可執行操作： 修改商品
```
```bash
- 權限： 10~100
- 職位： 店長
- 可執行操作： 新增商品、修改商品、刪除商品
```
```bash
- 權限： 1~10
- 職位： 系統管理員
- 可執行操作： 新增商品、修改商品、刪除商品
```

## 畫面

客人操作：
1. 會員登入/註冊畫面<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/ccfe8f64-2b87-4f31-93c2-bc91bc4b2748)
2. 會員註冊<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/84d2bdf4-f70d-402e-97d1-201c48f9f540)
3. 信箱與電話號碼不可重複註冊，密碼與再次輸入密碼需一致<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/c242425d-4fd6-4a00-85ee-9369f78fd8c3)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/530657d4-78f5-479e-a4e5-074018f5cd5a)
4. 使用者註冊成功，預設權限為1000，為客人權限<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/acce1d32-84f7-4eb1-85b6-d93ddd686e96)
5. 使用者登入<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/3483ea02-1cf5-44d6-9787-289b81d2d9da)
6. 點餐畫面，上方餐點種類選單按鈕可切換餐點，左下角查看購物車按鈕會計算購物車當中的品項數量<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/cfb8da1f-d8ad-496a-9587-19a842b377f6)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/47bc77d1-1de1-4bd7-8ed6-466a5bf4da42)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/61ab6a33-b0b8-4378-8b90-71d1738f1c54)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/74437a61-42cc-44d1-80c0-651e80ae7bf7)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/25839bc7-220a-4994-937b-4f707258e0e8)
7. 按下商品圖片可以看商品詳細資訊，按加入購物車進行點餐<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/1149e6a9-3a9f-4bc1-ae45-cdfd93c50a28)
8. 查看購物車，當配餐與超值全餐飲料數量比主餐多時，不可送出訂單，主餐可以單點<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/095dd1ef-d08a-44f8-b640-a9a20e6b5e0a)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/84815e4c-74b0-430e-921f-8b7f854f3d87)
9. 輸出明細表並送出訂單<br><br>
明細表：<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/9516d380-8d72-4c23-8190-6889c439846f)
<br>送出訂單：
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/67480f82-2242-449b-b217-8a22508681f4)
10. 修改會員資料：與註冊會員相同，信箱與電話號碼皆不可重複註冊，密碼與再次輸入密碼需一致<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/27caa5aa-9b3e-410b-b90c-f2beb0ae29fc)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/0a7208c3-17c8-44b8-a1cd-82feef2850f0)

商家操作，這裡以店長登入示範商品的新增、修改、刪除操作：
1. 店長登入<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/9540af7c-d9b3-445f-a172-a26054846ccf)
2. 新增商品，點選員工專區的"新增商品"進行新增商品操作<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/60b021f1-2b79-46b6-bcc5-b60214bb05e2)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/d2dc6901-ed90-4fac-9f9c-b451ff2c6e72)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/9fd455d5-3b04-4eb8-8177-ab27c9ae0431)
4. 修改商品，點選商品圖片即可進入商品管理頁面修改商品<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/7a991705-467f-419c-bc3a-b115b2fc323a)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/835d0d0d-1fbd-4a56-ad90-18746336ea4d)
5. 刪除商品，點選商品圖片即可進入商品管理頁面刪除商品，刪除前有確認視窗<br>
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/ee22a0f5-3f69-4b60-ab94-681538f6a9fa)
![image](https://github.com/tohousanae/WinformMacDonaldOrderSystem/assets/122202405/52b67dea-d62f-49b6-9597-262ebba25e1a)

## 引用資料
商品圖片、商品資訊文字取自麥當勞官網：https://www.mcdonalds.com/tw/zh-tw.html

## 注意事項
本專案為程式學習交流使用，請勿商用

