-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 
-- サーバのバージョン： 10.3.15-MariaDB
-- PHP のバージョン: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `hew2023`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `books_list`
--

CREATE TABLE `books_list` (
  `id` int(11) NOT NULL,
  `title` varchar(255) DEFAULT NULL,
  `author` varchar(255) DEFAULT NULL,
  `category_id` int(11) DEFAULT NULL,
  `recommendation_id` int(11) DEFAULT NULL,
  `image_date` varchar(255) DEFAULT NULL,
  `purchase_date` varchar(255) DEFAULT NULL,
  `registration_date` varchar(255) DEFAULT NULL,
  `delete_flag` int(1) DEFAULT NULL,
  `bookmark_flag` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `books_list`
--

INSERT INTO `books_list` (`id`, `title`, `author`, `category_id`, `recommendation_id`, `image_date`, `purchase_date`, `registration_date`, `delete_flag`, `bookmark_flag`) VALUES
(1, '君の膵臓をたべたい', '住野よる', 13, 4, NULL, '2022_02_15', NULL, NULL, 1),
(2, 'つくって覚えるC#入門', 'オフィス加減 著', 12, 3, NULL, '2021_09_03', NULL, NULL, 1),
(3, 'はらぺこあおむし', 'エリック・カール', 9, 5, NULL, '2022_01_13', NULL, NULL, NULL),
(4, 'ハイパフォーマンスPython', 'オライリージャパン', 12, 3, NULL, '2021_05_11', NULL, NULL, 1),
(5, '君を愛したひとりの僕へ', '乙野四方字', 2, 4, NULL, '2021_11_23', NULL, NULL, NULL),
(6, '僕が愛したすべての君へ', '乙野四方字', 2, 5, NULL, '2021_11_25', NULL, NULL, 1),
(7, '機動戦士ガンダム 逆襲のシャア―ベルトーチカ・チルドレン', '富野 由悠季', 2, 5, NULL, '2020_12_11', NULL, NULL, NULL),
(8, '天才を殺す凡人', '北野唯我', 13, 3, NULL, '2020_05_25', NULL, NULL, NULL),
(9, '機動戦士ガンダム 閃光のハサウェイ〈上〉', '富野 由悠季', 2, 5, '2022_03_03', '2022_02_22', NULL, NULL, 1),
(10, '機動戦士ガンダム 閃光のハサウェイ〈下〉', '富野 由悠季', 2, 5, NULL, '2022_02_22', NULL, NULL, 1),
(11, '図解 やっとわかった！ 大人のための中学数学', '中野 明', 10, 3, NULL, '2022_02_22', NULL, NULL, NULL),
(12, 'SHAMAN KING（１）', '武井 宏之', 7, 4, NULL, '2022_02_22', NULL, NULL, NULL),
(13, 'EDENS ZERO（1）', '真島ヒロ', 7, 5, NULL, '2022_02_22', NULL, NULL, NULL),
(14, 'SKET DANCE（１）', '篠原健太', 7, 5, NULL, '2022_02_20', NULL, NULL, NULL),
(15, '少年の日の思い出', 'ヘルマン・ヘッセ', 10, 4, NULL, '2022_02_02', NULL, NULL, NULL),
(16, '冴えない彼女の育てかた（１）', '丸戸史明', 14, 5, NULL, '2022_01_01', NULL, NULL, 1),
(17, 'ようこそ実力至上主義の教室へ（１）', '衣笠彰梧', 14, 5, NULL, '2022_01_01', NULL, NULL, NULL),
(18, 'かぐや様は告らせたい〜天才たちの恋愛頭脳戦〜（１）', '赤坂アカ', 7, 5, NULL, '2022_01_01', NULL, NULL, 1),
(19, 'FAIRY TAIL（1）', '真島ヒロ', 7, 5, NULL, '2022_01_22', NULL, NULL, 1),
(20, '呪術廻戦（１）', '芥見 下々', 7, 5, NULL, '2022_02_19', NULL, NULL, NULL),
(21, 'ポプテピピック（１）', '大川 ぶくぶ', 7, 1, NULL, '2021_12_25', NULL, NULL, NULL),
(22, 'ぼっち・ざ・ろっく!（1）', 'はまじあき', 7, 5, NULL, '2022_01_03', NULL, NULL, 1),
(23, 'ティモシーとサラの絵本 8 はながさくころに', '芭蕉みどり', 9, 3, NULL, '2022_01_19', '2022_03_28', NULL, 1),
(24, 'test', 'test', 12, 2, NULL, '2022_02_28', '2022_03_28', 1, NULL),
(25, '家族ゲーム', '本間 洋平', 2, 3, NULL, '2022_02_24', '2022_03_01', NULL, NULL),
(26, '冴えない彼女の育てかた（２）', '丸戸史明', 14, 5, NULL, '2021_10_28', '2022_03_02', NULL, 1),
(27, '冴えない彼女の育てかた（３）', '丸戸史明', 14, 5, NULL, '2022_12_25', '2022_03_02', NULL, 1),
(28, '冴えない彼女の育てかた（４）', '丸戸史明', 14, 5, NULL, '2022_10_31', '2022_03_02', NULL, 1),
(29, '100万回死んだねこ 覚え違いタイトル集', '福井県立図書館', 9, 3, NULL, '2021_07_23', '2022_03_03', 1, NULL),
(30, '100万回生きたねこ', '佐野 洋子', 9, 3, NULL, '2021_07_23', '2022_03_03', NULL, NULL);

-- --------------------------------------------------------

--
-- テーブルの構造 `category_list`
--

CREATE TABLE `category_list` (
  `id` int(11) NOT NULL,
  `value` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `category_list`
--

INSERT INTO `category_list` (`id`, `value`) VALUES
(1, '文芸書'),
(2, '文庫・新書'),
(3, '社会・経済'),
(4, '人文・教育'),
(5, '理工書'),
(6, '実用書'),
(7, 'コミック'),
(8, '芸術・音楽'),
(9, '児童書'),
(10, '語学・学参'),
(11, '医学・福祉'),
(12, 'PC'),
(13, '一般'),
(14, 'ライトノベル');

-- --------------------------------------------------------

--
-- テーブルの構造 `password`
--

CREATE TABLE `password` (
  `id` int(11) NOT NULL,
  `value` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='パスワードって名前のテーブル名にしたらダメ！';

--
-- テーブルのデータのダンプ `password`
--

INSERT INTO `password` (`id`, `value`) VALUES
(1, '1234'),
(2, '6666'),
(3, '3333');

-- --------------------------------------------------------

--
-- テーブルの構造 `qr_list`
--

CREATE TABLE `qr_list` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- テーブルの構造 `recommendation_list`
--

CREATE TABLE `recommendation_list` (
  `id` int(11) NOT NULL,
  `value` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `recommendation_list`
--

INSERT INTO `recommendation_list` (`id`, `value`) VALUES
(1, 'とても悪い'),
(2, '悪い'),
(3, '普通'),
(4, '良い'),
(5, 'とても良い');

-- --------------------------------------------------------

--
-- テーブルの構造 `user_list`
--

CREATE TABLE `user_list` (
  `id` int(11) NOT NULL,
  `authorization` int(11) NOT NULL,
  `user` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `user_list`
--

INSERT INTO `user_list` (`id`, `authorization`, `user`) VALUES
(1, 1, '0000'),
(2, 0, '0110'),
(3, 1, '2222');

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `books_list`
--
ALTER TABLE `books_list`
  ADD PRIMARY KEY (`id`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `recommendation_id` (`recommendation_id`);

--
-- テーブルのインデックス `category_list`
--
ALTER TABLE `category_list`
  ADD PRIMARY KEY (`id`);

--
-- テーブルのインデックス `password`
--
ALTER TABLE `password`
  ADD PRIMARY KEY (`id`);

--
-- テーブルのインデックス `qr_list`
--
ALTER TABLE `qr_list`
  ADD PRIMARY KEY (`id`);

--
-- テーブルのインデックス `recommendation_list`
--
ALTER TABLE `recommendation_list`
  ADD PRIMARY KEY (`id`);

--
-- テーブルのインデックス `user_list`
--
ALTER TABLE `user_list`
  ADD PRIMARY KEY (`id`);

--
-- ダンプしたテーブルのAUTO_INCREMENT
--

--
-- テーブルのAUTO_INCREMENT `books_list`
--
ALTER TABLE `books_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- テーブルのAUTO_INCREMENT `category_list`
--
ALTER TABLE `category_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- テーブルのAUTO_INCREMENT `password`
--
ALTER TABLE `password`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- テーブルのAUTO_INCREMENT `qr_list`
--
ALTER TABLE `qr_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- テーブルのAUTO_INCREMENT `recommendation_list`
--
ALTER TABLE `recommendation_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- テーブルのAUTO_INCREMENT `user_list`
--
ALTER TABLE `user_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- ダンプしたテーブルの制約
--

--
-- テーブルの制約 `books_list`
--
ALTER TABLE `books_list`
  ADD CONSTRAINT `books_list_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category_list` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `books_list_ibfk_2` FOREIGN KEY (`recommendation_id`) REFERENCES `recommendation_list` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
