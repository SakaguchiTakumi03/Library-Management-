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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

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
