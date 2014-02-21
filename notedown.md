#SAMPLE

##Quick Fixes Become Quicksand

為了很快地修好bug，即使不是很了解 code 怎麼運作，還是不明究理地加了奇怪的code修好了 (word-around)，因為寫這樣會炸，所以加了一行例外條件，blahblah… 然後沒人知道加那個條件是為什麼。anyway… 下一個 programmer 看到這行怎麼辦？ 有些 programmer 也許就跳過看不懂的這行，反正可以 work 就好。好的programmer 會搞清楚”為什麼”需要這行，更重要的是更會思考會有什麼副作用。

當一年一年過去，如果都沒有好的 programmer 在 refactor，可想得知這些 code 會恐怖到什麼程度，新增功能或fixed bug 將越來越困難。

粗淺的修正而沒有深度了解問題及可能的後果，也許當下 it look like it works，但是他傷害的程式可讀性，你可能會碰到有人說”不要改那裡，因為blah blah”，但當他離職了，就沒有知道那裡是幹麼的。

有幾種方式可以改善：

1.不要讓 developer 完全獨立寫 code，developer 要花時間去看別人的 code，確保程式的可讀性及可以理解。程式是寫給人看的，不是給機器看的。

2.寫 unit testing，在寫 testing 的過程中，你會轉換思維成如何設計 API，這將幫助你設計出更好呼叫及更清楚的程式。好的 unit testing 甚至可以當做一種可執行的文件，這也是 BDD 所強調的思維。

##Know when to unlearn (知道什麼是過時的技術)

技術在進步，有時候必須把舊東西給丟掉學新的，例如CPU變快了，Developer time 變重要了，很多以往的舊寫法不再適用必須丟掉。不過最困難的第一步就是了解到是否用了過期的解法。

##Let Customers make decisions (讓金主做決策)

當碰到設計上的決策時，尤其是 business-critical 決策，例如有兩個解決方案，一個複雜耗時長，另一個較簡單花較少時間。這時不要自己先決定，而是準備好資料(優缺點跟耗時估算)向金主(客戶)並用他們聽的懂的語言，讓他們決定。我自己的經驗是常常你打算做的沒有客戶想要的這麼複雜唷，這時候就可以省下這些時間去做真正客戶要的。

記得紀錄下來每個決定跟理由，當然你的問題也不能太技術細節，而是要有關係到 business。當然客戶也有可能說不知道，那麼你只好說出你覺得最好的建議。

##Justify Technology Use (評估使用的技術)

根據需求來選擇使用什麼技術、語言或 framework，每項技術都有優點缺點跟 trade-offs。
“The less code you write, the less you have to maintain”。可以下載到的東西，不需要自己寫。

##Integrate Early, Integrate Often (盡早整合、時常整合)

許多人會會延後整合，畢竟系統最後再整合就好，只要現在自己的 sub-system 可以動就好。但如果你一直只開發自己的東西，而越慢跟別人的東西整合在一起，越是辛苦。建議整合的次數從一天好幾次，到至多兩三天也至少有一次。

我自己的經驗是，你在分支(branch)開發一個功能，而主幹(trunk)同時也有別人在繼續進行，這時候建議時常要從 trunk merge 進你的 branch，可以的話每天進行，而不是等到最後才進行合併，最後才合併可能就merge不起來了，差異太大。

隔離開發(isolate)可以讓你開發更快避免干擾，但 isolate 與 integrate 不是不能同時進行，我們可以透過 mock object 技術在 isolate 的環境中測試你的 sub-system。透過盡早整合，你會發現你的 sub-system 與其他 sub-system 如何互動，越早了解問題所在，修好它的工作困難度就越低。

##Listen to Users (聆聽使用者)

作者在這章最後特別提了使用者的回饋。即使有寫測試程式，我們還是很容易忽略來自真正使用者的聲音。每一個使用者的抱怨都有其道理，盡量試著找出真正的問題，而不是怪罪使用者不懂、不了解系統如何操作。
程式Bug、文件Bug、使用者會認知錯誤也要算是Bug。而不是讓客服人員回答說：喔，那不是Bug, 你犯了一個大家都會犯的錯誤。即使聽起來很笨，也應該去試著聆聽。

##Program Intently and Expressively (寫清楚了解的程式)

厲害的程式是沒有人可以看懂的程式？程式的可閱讀性比寫得方便還重要，寫只會寫一遍，看卻會看很多次。很多時候會有機會要修 Bugs 或是新增功能，這時搞懂本來的程式常常是一開始最困難的地方，如果一開始寫的人就以可讀性為重要目標，那你就會輕鬆的多。

舉個我自己常見的例子就是 Magic Number，很多人喜歡是一個數字來代表 Type code。例如 1 代表 foo、2 代表 bar、3代表…etc，然後程式裡面就直接寫 1, 2, 3。方便是方便，但是沒多久就會忘記這個 1,2,3 各代表什麼意義。最簡單的解決手法就是請改用字串 constant 處理，或者是用 class 來表示 type。

透過程式語言本身的特色可以寫出更有表達力的程式，函數名稱應該傳達出意圖、參數名稱應該表達出他們的用途，寫出好閱讀的程式我們可以避免很多不必要的註解跟說明文件。一些你覺得明顯簡單的地方，不一定對別人也是如此明顯，甚至是幾個月後的你自己。請想想看幾個月後自己來看還會看得懂嗎?

##Communicate in Code (寫出可以閱讀的程式)

我們都討厭寫文件的一大理由是：所謂的文件跟程式碼常是分開的兩碼子事，因此很難讓文件跟的上程式的更新，最終變得難以維護。因此最好的寫文件方式，就是透過程式本身和程式中的註解。

註解是用來寫目的、限制條件跟預期結果等，而不是寫出以下這些程式一行行會做些什麼(請不要拿註解再寫一次程式碼在寫的事情)。一個簡單的判斷方式是：寫在函式 “裡面” 的註解多半是不需要的 (尤其是註解寫 what? 而不是註解 why?)。在重構一書更直言回答哪裡需要重構？那就是有註解的地方：如果程式碼前方有一行註釋，就是在提醒你，可以將這段程式碼替換成一個函式，而且可以在註釋的基礎上給這個函式命名。

你要做的事情應該是讓 source code 本身容易了解，而不是透過註解。透過正確的變數命名、好的空白間隔、邏輯分離清楚的執行路徑等手法，我們很少需要在函式裡面註明這些程式在做什麼，我自己的經驗除非是有參考外部的程式碼或複雜演算法，我會多註明參考來源(網址)。否則沒有必要的註解對我來說就像噪音一樣，妨礙閱讀。

變數跟函式的命名是件非常重要的事情，有意義的命名可以傳達出程式怎麼進行，我舉個 Rails 例子：


p = Post.find(param[:id])
if p
   p.destroy
else
   p = Post.new( param[:post] )
   p.save
end

可以改寫成以下這樣具有清楚意含：

existed_post = Post.find(param[:id])
if existed_post
  existed_post.destroy
else
  new_post = Post.new( param[:post] )
  new_post.save
end

有一種 Job security 的方式就是把程式中所有的變數名稱都代換成亂碼，保證拿到的人超級難看得懂。這就是為什麼手工打造的程式碼有其不可取代的重要性，只要拿到整合型 IDE 像是 Dreamweaver 產生出來的 HTML/CSS code 都很想殺人，因為裡面的變數都是編號產生出來的，根本沒辦法閱讀及擴充。

另外就是大家很喜歡用縮寫，這在我之前寫的文章 物件導向程式的九個體操練習 也有提到，這些只有一個字母的暫時變數並沒有辦法傳達出任何可以幫助了解的資訊。

Class, module, method 前面是個寫註解的好地方，而且每個語言都有工具(例如 RDoc, Javadoc… 等)可以幫忙從程式碼中整理出好看的純文件，這些說明通常有：

Purpose 目的
Requirements(pre-conditions) 預期的輸入是什麼
Promises(post-conditions) 什麼樣的輸入，會有什麼樣的預期輸出
Exceptions: 有哪些例外(exceptions)情況
這些說明可以幫助我們由大局觀了解程式是怎麼運作的，而不需要仔細看其中每個 method。

##Actively Evaluate Trade-Offs (積極地評估 Trade-offs)

效能很重要，但是如果 Performance 已經達到合理要求了，請也考慮實做方不方便、花費的成本跟時間，而不是只想”更快一點”了。天底下沒有完美的解決方案，一切都有 trade-off，如果沒辦法做決定，請去問金主。

這裡的名言警句還是那句老話：Premature optimization is the root of all evil.

##Keep It Simple (保持精巧)

當學到新的 Patterns、Principles 或技術時，請抵擋住過度設計和過度複雜化程式碼的壓力。例如在學 GoF 書的時候，很多人常會過度套用其中的樣式，而造成過度設計。盡量發展出最簡明的解決方案，任何笨蛋都有辦法把程式寫的更大更複雜更暴力。

對 Simplicity 概念有興趣的朋友，我推薦可以去翻翻這本書
簡單的法則。

##Write Cohesive Code (高內聚力的程式)

內聚力一種評估元件裡面的功能相關度高低的概念。如何組織元件 (例如要寫一段新程式，第一件事就是決定要把這段程式放在哪裡) 會造成生產力和維護上的重大的影響。一個元件(component)中的類別應該是要高度相關的、一個類別中的函式應該是要高度相關的。

為什麼內聚力重要？因為我們都希望軟體能夠容易被修改，一旦需要修改，我們希望能夠跳到程式中的某一段，然後只要在那裡改好就可以了。一個內聚力不夠的軟體，當你要修改程式的時候就得多翻很多地方，每遇到某種變化，而要修改的程式碼散佈四處，不但難以找到，也很容易忘記(在重構一書的，指這種壞味道叫做散彈式修改)。

另一個低內聚力的後果是發散式變化：比如說一個類別裡面有五個功能全異的函式，那麼當這五個函式任一個發生需求時，我們就必須要去修改這個類別，而一個頻於修改的不穩定類別會造成維護上的不易。有個物件導向的原則就是在講這件事：Single Responsibility Principle (SRP) 類別變更的原因應僅只有一種 ，換句話說就是一個物件只因一種變化而需要修改。

一個內聚力很糟的例子就是傳統的 PHP/ASP 程式了，每一頁都有 HTML, JavaScript, embedded SQL, business login 全部混在一起，當要變更 Table schema 時，就必須每個頁面都要修改，真是災難一場。解決方法就是引進 MVC 的架構，分離出 presentation logic 和 business logic。

這節的忠告是：一個類別應該要夠聚焦(focused)、一個元件(component)應該要夠小，避免寫出太大的類別或元件、避免寫出功能混雜的通吃類別。

##Tell, Don’t Ask

“Procedural code gets information and then makes decisions. Object-oriented code tells objects to do things” by Alec Sharp.

你應該告訴物件你想要什麼(tell)，而不是去問(ask)物件的狀態，然後做決定再告訴物件要做什麼。根據被呼叫者的狀態來做決定的邏輯應該是被呼叫者的責任。

一個跟 Tell, Don’t Ask 相關的手法是把所有你的函式都只分成 Command 和 Query 兩種，前者會改變某種狀態(為了方便也許會回傳一些值)，後者只是查詢不會有任何更動。Command Query Separation 手法的原意是避免 side-effect，不要同時修改又查詢狀態，以方便測試及除錯。而在這裡透過這個手法也可以同時幫助我們思考 Tell, Don’t Ask。

在 Smalltalk 語言中用 “message passsing” 取代 method calls 一詞，這跟 Tell, Don’t Ask 的感覺類似，像是送訊息而不是執行功能。延伸閱讀可以看看 The Pragmatic Bookshelf 的 Tell, Don’t Ask 一文。

##Keep a Solutions Log (紀錄下解決問題的辦法)

解決問題一直是軟體開發者的工作項目(這裡指的問題比較像是軟體安裝、版本、函式庫使用等等問題，例如 windows 上如何把 MySQL Ruby gem 裝起來等等)，不過有時候會碰到似曾相似的問題，疑？我以前是怎麼解決的？拜網路發達之賜，Google 搜尋一下通常會有不少幫助，但是還是得花不少時間找尋解答。

自己維護一份簡單的 solutions log 吧，紀錄下日期、問題描述、解法、參考網址等等資訊，之後碰到類似的問題就可以搜尋的到。將這份 log 用 wiki 維護也是不錯的主意。或是寫在 Blog 上，這樣 google 搞不好還會搜尋到自己以前寫的解法…XD

##Warnings Are Really Errors (把警告當真)

編譯器(這裡泛指 complier 或 interpreter) 的警告常常有人是忽略不看的，反正可以編譯執行不會 error 就好了？書上舉了 C++ 的例子，編譯器的警告還是蠻有用的(我想特別是 static 語言)可以幫助你找到跟避免潛在的 Bugs，請不要忽略。請將編譯器的警告也當作程式錯誤或無法通過測試的程式一樣認真處理。

我自己寫 Ruby/Rails 的經驗，最常見的警告像是有：


link_to ( 'login', login_path ) # warning: don't put space before argument parentheses

因為中間多了一個沒用的空白。或是

p Array.new 3, 1 # warning: parenthesize argument(s) for future version

因為 interpreter 覺得 ambiguities 不清楚，這時要請你括號括清楚。另外就是 DEPRECATION WARNING 警告了，告訴你這函式將來的版本將會移除，請不要再用了 :p

##Report All Exceptions (回報所有的例外)

如果呼叫一個可能會丟例外的函式，當碰到例外時，盡量可以處理就處理，不然請讓他自然傳播(Propagate)上去給上一層 Caller 處理，不要攔下來又什麼都不做。如果在整個 call stack 中有個傢伙寫了個空個 catch 所有例外，然後 return null 什麼都不做，到時候要找 Bugs 你就會很想殺人了，因為非得 trace 進去 call stack 才能找到原因。

不要覺得自己不會這樣寫，其實常常我們會想”暫時”不想處理這個例外，於是就留下這樣空的例外處理程式碼(然後繼續留到 Production code)。決定要在哪一層處理例外是個設計上的考量，但是如果呼叫一個函式卻要考慮處理二三十種以上的例外可能就有設計上的問題了。

##Architects Must Write Code (架構設計師一定要寫程式)

軟體架構設計師已經變成有點被濫用的職稱了，一個只會畫好看的圖、講厲害的行話、用一堆 Patterns，但是真的要實做前就跑走的設計師是沒有用的。真的設計隨著實際開始實做、實際的 Feedback 之後才會逐漸演化。就像打戰一樣，一旦開打 Plan 就無用了，只能不斷地 Planning，策略決策也許千里遠可以做，但是戰術決定非得實際在戰場上了解才行。

The designer of a new kind of system must participate fully in the implementation. by Donald E. Knuth

作為一個架構設計師，要實際了解設計真的可行才算是負責。真正的 architect 是團隊中的導師，有能力解決較複雜的問題，但絕不放棄 coding。絕對不要用不 coding 的架構設計師，不實際 coding 了解系統是不可能設計好軟體的。 * Good Design evolves from active programmers. *

##Practice Collective Ownership (練習集體擁有感)

“這個地方是 xxx 寫的，只有等他放假回來才能修的好”，這種事情很糟糕。請避免讓某一段 code 只能由某特定 developer 處理的情況，試著輪調 developer 去寫系統中不同的模組，分別由不同的人看過也可以讓程式更加被 checked、refactored 和 maintained 過，一旦碰到哪裡急需要修 Bugs 也不會發生等人的窘境。

當然，也許讓 developer 專屬某一領域的工作可能會開發一時會比較快速，不過放長遠一點看，透過多人共同開發的方式會獲得比較好的程式品質，也會比較好維護。整個團隊的 developers 的平均水準也可以拉高。對 developer 來說，知道寫出來的程式將來會被別人看，也會寫的更加用心。

這件事做起來當然是要注意過猶不及，例如太頻繁的輪調造成混亂或是系統中真的有某處需要特定人的特定專業知識。重點是 “你可以不需要了解系統中的每個細節，但是你也不應該害怕要你接手處理系統中的任何一塊”。

在 XP 方法論中，這件事情更是直接透過 Pair Programming 來達成，每一段 code 至少被兩個人擁有(處理) :p

##Share Code Only When Ready (只 commit 準備好的程式)

千萬不要把(已知)會爛掉的程式 commit 進入版本控制系統，不然其他人更新最新版本之後不能正常執行，影響開發進度。請在做完一個任務或解完 Bug 之後，通過 unit test 之後再 commit 進去。當然，”It’s not ready” 不是一個久久不 commit 的藉口。

