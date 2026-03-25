/*
 Navicat Premium Data Transfer

 Source Server         : ssy
 Source Server Type    : MySQL
 Source Server Version : 50734
 Source Host           : 47.116.26.2:3306
 Source Schema         : ssy

 Target Server Type    : MySQL
 Target Server Version : 50734
 File Encoding         : 65001

 Date: 04/07/2024 18:10:37
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sys_log_operate
-- ----------------------------
DROP TABLE IF EXISTS `sys_log_operate`;
CREATE TABLE `sys_log_operate`  (
  `Id` bigint(20) NOT NULL COMMENT 'Id',
  `ExeMessage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '具体消息',
  `ClassName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '类名称',
  `MethodName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '方法名称',
  `ReqMethod` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '请求方式',
  `ReqUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '请求地址',
  `ParamJson` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '请求参数',
  `ResultJson` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '返回结果',
  `Category` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '日志分类',
  `Name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '日志名称',
  `ExeStatus` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '执行状态',
  `OpIp` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作ip',
  `OpAddress` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作地址',
  `OpBrowser` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作浏览器',
  `OpOs` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作系统',
  `OpTime` datetime NOT NULL COMMENT '操作时间',
  `OpUser` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作人姓名',
  `OpAccount` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作人账号',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '创建时间',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '更新时间',
  `CreateUserId` bigint(20) NULL DEFAULT NULL COMMENT '创建者Id',
  `UpdateUserId` bigint(20) NULL DEFAULT NULL COMMENT '修改者Id',
  `CreateUser` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateUser` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '更新人',
  `IsDelete` tinyint(1) NULL DEFAULT NULL COMMENT '软删除',
  `ExtJson` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '扩展信息',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '操作日志表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_log_operate
-- ----------------------------
INSERT INTO `sys_log_operate` VALUES (564904494043205, NULL, 'SSY.Web.Core.Controllers.System.UserControllers.AddUser', 'addUser', 'POST', '/User/AddUser', '{\"account\":\"aaa\",\"password\":\"aaa\",\"name\":\"aaa\",\"roleId\":0}', '{\"Code\":200,\"Msg\":\"请求成功\",\"extras\":null,\"Data\":true,\"Time\":\"2024/7/4 16:22:11\"}', 'OPERATE', '添加用户', '成功', '127.0.0.1', '未知', 'Edge119', 'Windows10', '2024-07-04 16:22:12', '超级管理员2', 'admin', '2024-07-04 16:22:18', NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_log_visit
-- ----------------------------
DROP TABLE IF EXISTS `sys_log_visit`;
CREATE TABLE `sys_log_visit`  (
  `Id` bigint(20) NOT NULL COMMENT 'Id',
  `Category` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '日志分类',
  `Name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '日志名称',
  `ExeStatus` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '执行状态',
  `OpIp` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作ip',
  `OpAddress` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作地址',
  `OpBrowser` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作浏览器',
  `OpOs` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作系统',
  `OpTime` datetime NOT NULL COMMENT '操作时间',
  `OpUser` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作人姓名',
  `OpAccount` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作人账号',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '创建时间',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '更新时间',
  `CreateUserId` bigint(20) NULL DEFAULT NULL COMMENT '创建者Id',
  `UpdateUserId` bigint(20) NULL DEFAULT NULL COMMENT '修改者Id',
  `CreateUser` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateUser` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '更新人',
  `IsDelete` tinyint(1) NULL DEFAULT NULL COMMENT '软删除',
  `ExtJson` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '扩展信息',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '访问日志表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_log_visit
-- ----------------------------
INSERT INTO `sys_log_visit` VALUES (527753493225541, 'LOGIN', '登录', '成功', '111.85.26.222', '未知', 'Edge122', 'Windows10', '2024-03-21 16:54:30', '超级管理员2', 'admin', '2024-03-21 16:54:30', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (529512778080325, 'LOGIN', '登录', '成功', '220.197.183.141', '未知', 'Edge122', 'Windows10', '2024-03-26 16:13:03', '超级管理员2', 'admin', '2024-03-26 16:13:03', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (547524483772485, 'LOGIN', '登录', '成功', '111.85.26.136', '未知', 'Edge124', 'Windows10', '2024-05-16 13:42:52', '超级管理员2', 'admin', '2024-05-16 13:42:52', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (549596184207429, 'LOGIN', '登录', '成功', '47.116.26.2', '未知', 'Chrome125', 'Windows10', '2024-05-22 10:12:38', '超级管理员2', 'admin', '2024-05-22 10:12:38', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (549600626139205, 'LOGIN', '登录', '成功', '220.197.185.215', '未知', 'Edge119', 'Windows10', '2024-05-22 10:30:42', '超级管理员2', 'admin', '2024-05-22 10:30:42', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (549601810788421, 'LOGIN', '登录', '成功', '220.197.185.215', '未知', 'Edge119', 'Windows10', '2024-05-22 10:35:32', '超级管理员2', 'admin', '2024-05-22 10:35:32', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (549601868222533, 'LOGIN', '登录', '成功', '220.197.185.215', '未知', 'Edge119', 'Windows10', '2024-05-22 10:35:46', '超级管理员2', 'admin', '2024-05-22 10:35:46', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (549602040438853, 'LOGIN', '登录', '成功', '220.197.185.215', '未知', 'Chrome116', 'Windows10', '2024-05-22 10:36:28', '超级管理员2', 'admin', '2024-05-22 10:36:28', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (549969398128709, 'LOGIN', '登录', '成功', '220.197.185.215', '未知', 'Edge119', 'Windows10', '2024-05-23 11:31:15', '超级管理员2', 'admin', '2024-05-23 11:31:15', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (557134771556421, 'LOGIN', '登录', '成功', '220.197.185.100', '未知', 'Edge125', 'Windows10', '2024-06-12 17:27:13', '超级管理员2', 'admin', '2024-06-12 17:27:13', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (562056241328197, 'LOGIN', '登录', '成功', '127.0.0.1', '未知', 'Edge119', 'Windows10', '2024-06-26 15:12:44', '超级管理员2', 'admin', '2024-06-26 15:12:44', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (563853586276421, 'LOGIN', '登录', '成功', '111.85.26.240', '未知', 'Edge126', 'Windows10', '2024-07-01 17:06:09', '超级管理员2', 'admin', '2024-07-01 17:06:09', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (564855797956677, 'LOGIN', '登录', '成功', '127.0.0.1', '未知', 'Edge119', 'Windows10', '2024-07-04 13:04:09', '超级管理员2', 'admin', '2024-07-04 13:04:10', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_log_visit` VALUES (564903546400837, 'LOGIN', '登录', '成功', '127.0.0.1', '未知', 'Edge119', 'Windows10', '2024-07-04 16:18:27', '超级管理员2', 'admin', '2024-07-04 16:18:27', NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu`  (
  `id` bigint(20) NOT NULL COMMENT '主键Id',
  `parent_id` bigint(20) NOT NULL COMMENT '父Id',
  `menu_type` int(11) NOT NULL COMMENT '菜单类型',
  `name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '路由名称',
  `path` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '路由地址',
  `component` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '组件路径',
  `authority` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '权限标识',
  `title` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '菜单名称',
  `icon` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '图标',
  `order_no` int(11) NOT NULL COMMENT '排序',
  `is_hide` tinyint(1) NOT NULL COMMENT '是否隐藏',
  `is_delete` tinyint(1) NOT NULL COMMENT '软删除',
  `create_time` datetime NULL DEFAULT NULL COMMENT '创建时间',
  `update_time` datetime NULL DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '系统菜单表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES (1300000000101, 0, 2, 'dashboard', '/dashboard', '', NULL, '工作台', 'AnalysisOutlined', 0, 0, 0, '2024-02-13 19:05:28', '2024-03-18 20:28:30');
INSERT INTO `sys_menu` VALUES (1300000000111, 1300000000101, 2, 'home', '/dashboard/home', '/home/index', NULL, '工作台', 'ClusterOutlined', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-18 09:20:16');
INSERT INTO `sys_menu` VALUES (1310000000101, 0, 2, 'system', '/system', '', NULL, '系统管理', 'SettingOutlined', 11000, 0, 0, '2024-02-13 19:05:28', '2024-03-18 20:33:37');
INSERT INTO `sys_menu` VALUES (1310000000111, 1310000000101, 2, 'sys_menu', '/system/menu', '/system/menu/index', '', '菜单管理', 'AppstoreOutlined', 120, 0, 0, '2024-02-13 19:05:28', '2024-03-20 16:34:10');
INSERT INTO `sys_menu` VALUES (1310000000112, 1310000000111, 3, NULL, '', '', 'sys:menu:search', '查询菜单', '', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-19 18:11:03');
INSERT INTO `sys_menu` VALUES (1310000000113, 1310000000111, 3, NULL, '', '', 'sys:menu:update', '编辑菜单', '', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-19 18:10:49');
INSERT INTO `sys_menu` VALUES (1310000000114, 1310000000111, 3, NULL, '', '', 'sys:menu:add', '增加菜单', '', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-19 18:11:14');
INSERT INTO `sys_menu` VALUES (1310000000115, 1310000000111, 3, NULL, '', '', 'sys:menu:delete', '删除菜单', '', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-19 18:11:21');
INSERT INTO `sys_menu` VALUES (1310000000121, 1310000000101, 2, 'sys_role', '/system/role', '/system/role/index', NULL, '角色管理', 'IdcardOutlined', 130, 0, 0, '2024-03-11 16:01:02', '2024-03-20 11:37:38');
INSERT INTO `sys_menu` VALUES (1310000000131, 1310000000101, 2, 'sys_user', '/system/user', '/system/user/index', NULL, '用户管理', 'UserOutlined', 110, 0, 0, '2024-03-11 16:03:55', '2024-03-20 11:37:25');
INSERT INTO `sys_menu` VALUES (1310000000161, 1310000000101, 2, 'sys_user_center', '/system/userCenter', '/system/userCenter/index', NULL, '个人中心', 'ControlOutlined', 140, 0, 0, '2024-02-13 19:05:28', '2024-03-20 11:37:43');
INSERT INTO `sys_menu` VALUES (1310000000162, 1310000000161, 3, NULL, NULL, NULL, 'sys:user:changePwd', '修改密码', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-03-19 18:14:01');
INSERT INTO `sys_menu` VALUES (1310000000163, 1310000000161, 3, NULL, NULL, NULL, 'sys:user:baseInfo', '基本信息', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-03-19 18:14:08');
INSERT INTO `sys_menu` VALUES (1310000000301, 0, 1, 'platform', '/platform', '', NULL, '平台管理', 'ArrowRightOutlined', 12000, 0, 0, '2024-02-13 19:05:28', '2024-03-20 16:16:49');
INSERT INTO `sys_menu` VALUES (1310000000311, 1310000000301, 2, 'sysTenant', '', '', '', '租户管理', '', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-20 16:33:17');
INSERT INTO `sys_menu` VALUES (1310000000312, 1310000000311, 3, NULL, NULL, NULL, 'sysTenant:page', '查询', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000313, 1310000000311, 3, NULL, NULL, NULL, 'sysTenant:update', '编辑', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000314, 1310000000311, 3, NULL, NULL, NULL, 'sysTenant:add', '增加', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000315, 1310000000311, 3, NULL, NULL, NULL, 'sysTenant:delete', '删除', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000351, 1310000000301, 2, 'sysJob', '/platform/job', '/system/job/index', NULL, '任务调度', 'ele-AlarmClock', 140, 0, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000352, 1310000000351, 3, NULL, NULL, NULL, 'sysJob:pageJobDetail', '查询', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000353, 1310000000351, 3, NULL, NULL, NULL, 'sysJob:updateJobDetail', '编辑', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000354, 1310000000351, 3, NULL, NULL, NULL, 'sysJob:addJobDetail', '增加', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000355, 1310000000351, 3, NULL, NULL, NULL, 'sysJob:deleteJobDetail', '删除', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000371, 1310000000301, 2, 'sysCache', '/platform/cache', '/system/cache/index', NULL, '缓存管理', 'ele-Loading', 160, 0, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000372, 1310000000371, 3, NULL, NULL, NULL, 'sysCache:keyList', '查询', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000373, 1310000000371, 3, NULL, NULL, NULL, 'sysCache:delete', '删除', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-02-13 19:05:28');
INSERT INTO `sys_menu` VALUES (1310000000501, 0, 0, 'log', '/log', '', NULL, '日志管理', 'DatabaseOutlined', 13000, 0, 0, '2024-03-01 10:52:52', '2024-03-18 20:36:20');
INSERT INTO `sys_menu` VALUES (1310000000511, 1310000000501, 1, 'sysVisLog', '/log/vislog', '/system/log/vislog/index', NULL, '访问日志', 'FileOutlined', 100, 0, 0, '2024-02-13 19:05:28', '2024-03-18 20:36:28');
INSERT INTO `sys_menu` VALUES (1310000000512, 1310000000511, 3, NULL, NULL, NULL, 'sys:vislog:page', '查询', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-03-19 18:15:35');
INSERT INTO `sys_menu` VALUES (1310000000513, 1310000000511, 3, NULL, NULL, NULL, 'sys:vislog:clear', '清空', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-03-19 18:15:43');
INSERT INTO `sys_menu` VALUES (1310000000521, 1310000000501, 1, 'sysOpLog', '/log/oplog', '/system/log/oplog/index', NULL, '操作日志', 'LogOutlined', 110, 0, 0, '2024-02-13 19:05:28', '2024-03-18 20:37:10');
INSERT INTO `sys_menu` VALUES (1310000000522, 1310000000521, 3, NULL, NULL, NULL, 'sys:oplog:page', '查询', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-03-19 18:15:57');
INSERT INTO `sys_menu` VALUES (1310000000523, 1310000000521, 3, NULL, NULL, NULL, 'sys:oplog:clear', '清空', NULL, 100, 1, 0, '2024-02-13 19:05:28', '2024-03-19 18:16:05');
INSERT INTO `sys_menu` VALUES (525641812480069, 1300000000101, 2, NULL, '/dashboard/home1', '/dashboard/home1/index', '', '首页', 'AppstoreAddOutlined', 101, 0, 0, '2024-03-15 17:42:03', '2024-03-20 11:37:53');
INSERT INTO `sys_menu` VALUES (527018197459013, 1310000000121, 3, NULL, NULL, '', 'sys:role:add', '增加角色', '', 100, 0, 0, '2024-03-19 15:02:34', '2024-03-19 18:12:29');
INSERT INTO `sys_menu` VALUES (527018297729093, 1310000000121, 3, NULL, NULL, '', 'sys:role:delete', '删除角色', '', 100, 0, 0, '2024-03-19 15:02:59', '2024-03-19 18:11:53');
INSERT INTO `sys_menu` VALUES (527018365534277, 1310000000121, 3, NULL, NULL, '', 'sys:role:update', '修改角色', '', 100, 0, 0, '2024-03-19 15:03:15', '2024-03-19 18:12:06');
INSERT INTO `sys_menu` VALUES (527018447958085, 1310000000121, 3, NULL, NULL, '', 'sys:role:search', '查询角色', '', 100, 0, 0, '2024-03-19 15:03:35', '2024-03-19 18:12:22');
INSERT INTO `sys_menu` VALUES (527018525585477, 1310000000131, 3, NULL, NULL, '', 'sys:user:add', '增加用户', '', 100, 0, 0, '2024-03-19 15:03:54', '2024-03-19 18:12:56');
INSERT INTO `sys_menu` VALUES (527018590720069, 1310000000131, 3, NULL, NULL, '', 'sys:user:delete', '删除用户', '', 100, 0, 0, '2024-03-19 15:04:10', '2024-03-19 18:13:08');
INSERT INTO `sys_menu` VALUES (527018633273413, 1310000000131, 3, NULL, NULL, '', 'sys:user:update', '修改用户', '', 100, 0, 0, '2024-03-19 15:04:21', '2024-03-19 18:13:22');
INSERT INTO `sys_menu` VALUES (527018676727877, 1310000000131, 3, NULL, NULL, '', 'sys:user:search', '查询用户', '', 100, 0, 0, '2024-03-19 15:04:31', '2024-03-19 18:13:34');
INSERT INTO `sys_menu` VALUES (529511643398213, 0, 1, NULL, '/project', '', '', '工程管理', 'IdcardOutlined', 20000, 0, 1, '2024-03-26 16:08:26', NULL);
INSERT INTO `sys_menu` VALUES (529512044421189, 529511643398213, 2, NULL, '/project/getDate', '/project/getDate/index', '', '工程管理', 'FileOutlined', 120, 0, 1, '2024-03-26 16:10:03', '2024-03-26 16:17:00');
INSERT INTO `sys_menu` VALUES (529513452052549, 529511643398213, 2, NULL, '/project/need', '/project/need/index', '', '需求管理', 'HomeOutlined', 10002, 0, 1, '2024-03-26 16:15:47', NULL);

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `id` bigint(20) NOT NULL COMMENT '主键Id',
  `name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '名称',
  `remark` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '备注',
  `status` int(11) NOT NULL COMMENT '状态',
  `create_time` datetime NULL DEFAULT NULL COMMENT '创建时间',
  `update_time` datetime NULL DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '系统角色表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES (1300000000101, '系统管理员', '系统管理员', 1, '2024-02-13 19:05:29', '2024-02-13 19:05:29');

-- ----------------------------
-- Table structure for sys_role_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_menu`;
CREATE TABLE `sys_role_menu`  (
  `id` bigint(20) NOT NULL COMMENT '主键Id',
  `role_id` bigint(20) NOT NULL COMMENT '角色Id',
  `menu_id` bigint(20) NOT NULL COMMENT '菜单Id',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '系统角色菜单表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_role_menu
-- ----------------------------
INSERT INTO `sys_role_menu` VALUES (552087850328133, 1300000000101, 1300000000101);
INSERT INTO `sys_role_menu` VALUES (552087850328134, 1300000000101, 1300000000111);
INSERT INTO `sys_role_menu` VALUES (552087850328135, 1300000000101, 525641812480069);
INSERT INTO `sys_role_menu` VALUES (552087850328136, 1300000000101, 1310000000111);
INSERT INTO `sys_role_menu` VALUES (552087850328137, 1300000000101, 1310000000112);
INSERT INTO `sys_role_menu` VALUES (552087850328138, 1300000000101, 1310000000113);
INSERT INTO `sys_role_menu` VALUES (552087850328139, 1300000000101, 1310000000114);
INSERT INTO `sys_role_menu` VALUES (552087850328140, 1300000000101, 1310000000115);
INSERT INTO `sys_role_menu` VALUES (552087850328141, 1300000000101, 1310000000121);
INSERT INTO `sys_role_menu` VALUES (552087850328142, 1300000000101, 527018197459013);
INSERT INTO `sys_role_menu` VALUES (552087850328143, 1300000000101, 527018297729093);
INSERT INTO `sys_role_menu` VALUES (552087850328144, 1300000000101, 527018365534277);
INSERT INTO `sys_role_menu` VALUES (552087850328145, 1300000000101, 527018447958085);
INSERT INTO `sys_role_menu` VALUES (552087850328146, 1300000000101, 1310000000131);
INSERT INTO `sys_role_menu` VALUES (552087850328147, 1300000000101, 527018525585477);
INSERT INTO `sys_role_menu` VALUES (552087850328148, 1300000000101, 527018590720069);
INSERT INTO `sys_role_menu` VALUES (552087850328149, 1300000000101, 527018633273413);
INSERT INTO `sys_role_menu` VALUES (552087850328150, 1300000000101, 527018676727877);
INSERT INTO `sys_role_menu` VALUES (552087850328151, 1300000000101, 1310000000501);
INSERT INTO `sys_role_menu` VALUES (552087850328152, 1300000000101, 1310000000511);
INSERT INTO `sys_role_menu` VALUES (552087850328153, 1300000000101, 1310000000512);
INSERT INTO `sys_role_menu` VALUES (552087850328154, 1300000000101, 1310000000513);
INSERT INTO `sys_role_menu` VALUES (552087850328155, 1300000000101, 1310000000521);
INSERT INTO `sys_role_menu` VALUES (552087850328156, 1300000000101, 1310000000522);
INSERT INTO `sys_role_menu` VALUES (552087850328157, 1300000000101, 1310000000523);
INSERT INTO `sys_role_menu` VALUES (552087850328158, 1300000000101, 1310000000101);

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user`  (
  `id` bigint(20) NOT NULL COMMENT 'Id',
  `account` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '账号',
  `password` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '密码',
  `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '姓名',
  `role_id` bigint(20) NOT NULL COMMENT '权限Id',
  `account_type` int(11) NOT NULL COMMENT '账号类型',
  `create_time` datetime NULL DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '用户信息表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES (1, 'admin', 'a059a206b4f58e06b92babcaf607e9c9', '超级管理员2', 1300000000101, 999, '2024-03-11 14:40:52');
INSERT INTO `sys_user` VALUES (564904466079813, 'aaa', 'b8cc737eb0e9d7574a1b93f39f841db4', 'aaa', 0, 0, '2024-07-04 16:22:11');

SET FOREIGN_KEY_CHECKS = 1;
