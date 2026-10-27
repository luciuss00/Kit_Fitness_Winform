USE KitFitness;
GO

-- 1. ADMINS (10 rows)
SET IDENTITY_INSERT [admins] ON;
INSERT INTO [admins] ([id], [user_name], [email], [password_hash], [role], [created_at], [updated_at], [is_deleted]) VALUES
(1, N'admin', 'admin@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'SUPER_ADMIN', GETDATE(), GETDATE(), 0),
(2, N'superadmin', 'superadmin@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'SUPER_ADMIN', GETDATE(), GETDATE(), 0),
(3, N'coach_hung', 'hung.coach@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'COACH', GETDATE(), GETDATE(), 0),
(4, N'coach_lan', 'lan.coach@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'COACH', GETDATE(), GETDATE(), 0),
(5, N'manager_dat', 'dat.manager@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'ADMIN', GETDATE(), GETDATE(), 0),
(6, N'coach_nam', 'nam.coach@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'COACH', GETDATE(), GETDATE(), 0),
(7, N'coach_mai', 'mai.coach@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'COACH', GETDATE(), GETDATE(), 0),
(8, N'support_team', 'support@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'ADMIN', GETDATE(), GETDATE(), 0),
(9, N'finance_admin', 'finance@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'ADMIN', GETDATE(), GETDATE(), 0),
(10, N'system_master', 'system@kitfitness.vn', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'SUPER_ADMIN', GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [admins] OFF;
GO

-- 2. USERS (10 rows)
SET IDENTITY_INSERT [users] ON;
INSERT INTO [users] ([id], [user_name], [target_calories], [height], [weight], [user_type], [meal_per_day], [age], [gender], [activity_level], [goal], [weekly_rate_kg], [target_weight_kg], [created_at], [updated_at], [is_deleted]) VALUES
(1, N'dat_fitness', 2200, 175.00, 72.50, 'PREMIUM', 3, 22, 'MALE', 'MODERATE', 'GAIN_MUSCLE', 0.5, 76.0, GETDATE(), GETDATE(), 0),
(2, N'hoang_nam', 2500, 180.00, 82.00, 'FREE', 4, 25, 'MALE', 'VERY_ACTIVE', 'LOSE_WEIGHT', 0.7, 75.0, GETDATE(), GETDATE(), 0),
(3, N'mai_anh', 1800, 162.00, 52.00, 'PREMIUM', 3, 21, 'FEMALE', 'LIGHT', 'MAINTAIN', 0.0, 52.0, GETDATE(), GETDATE(), 0),
(4, N'quang_huy', 2400, 172.00, 75.00, 'FREE', 3, 24, 'MALE', 'MODERATE', 'GAIN_MUSCLE', 0.5, 78.0, GETDATE(), GETDATE(), 0),
(5, N'thu_trang', 1600, 158.00, 50.00, 'PREMIUM', 3, 23, 'FEMALE', 'SEDENTARY', 'LOSE_WEIGHT', 0.4, 47.0, GETDATE(), GETDATE(), 0),
(6, N'tuan_anh', 2300, 178.00, 76.50, 'FREE', 4, 26, 'MALE', 'VERY_ACTIVE', 'GAIN_MUSCLE', 0.5, 80.0, GETDATE(), GETDATE(), 0),
(7, N'ngoc_linh', 1700, 165.00, 55.00, 'PREMIUM', 3, 22, 'FEMALE', 'LIGHT', 'MAINTAIN', 0.0, 55.0, GETDATE(), GETDATE(), 0),
(8, N'minh_duc', 2600, 182.00, 85.00, 'FREE', 4, 27, 'MALE', 'VERY_ACTIVE', 'LOSE_WEIGHT', 0.8, 77.0, GETDATE(), GETDATE(), 0),
(9, N'phuong_thao', 1650, 160.00, 49.00, 'PREMIUM', 3, 21, 'FEMALE', 'MODERATE', 'LOSE_WEIGHT', 0.4, 46.0, GETDATE(), GETDATE(), 0),
(10, N'viet_dung', 2100, 170.00, 68.00, 'FREE', 3, 24, 'MALE', 'LIGHT', 'MAINTAIN', 0.0, 68.0, GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [users] OFF;
GO

-- 3. ACCOUNTS (10 rows) - Mật khẩu chung: 123456
SET IDENTITY_INSERT [accounts] ON;
INSERT INTO [accounts] ([id], [user_id], [email], [password_hash], [recovery_code], [balance], [status], [provider], [provider_id], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, 'dat_fitness', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC01-DATF-1234-ABCD', 500000.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(2, 2, 'hoang_nam', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC02-HNAM-2345-BCDE', 0.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(3, 3, 'mai_anh', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC03-MANH-3456-CDEF', 250000.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(4, 4, 'quang_huy', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC04-QHUY-4567-DEFG', 0.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(5, 5, 'thu_trang', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC05-TTRA-5678-EFGH', 100000.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(6, 6, 'tuan_anh', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC06-TANH-6789-FGHI', 0.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(7, 7, 'ngoc_linh', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC07-NLIN-7890-GHIJ', 300000.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(8, 8, 'minh_duc', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC08-MDUC-8901-HIJK', 0.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(9, 9, 'phuong_thao', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC09-PTHA-9012-IJKL', 150000.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0),
(10, 10, 'viet_dung', '$2a$11$XG9.DFzIDIC1Ayk1yn.7rOhX4wpOAUoNlnC6k0qLUkrUw.gGobDQ.', 'RC10-VDUN-0123-JKLM', 50000.00, 'ACTIVE', 'LOCAL', NULL, GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [accounts] OFF;
GO

-- 4. FOODS (10 rows)
SET IDENTITY_INSERT [foods] ON;
INSERT INTO [foods] ([id], [name], [unit], [fat], [carbs], [protein], [calories], [is_custom], [create_by_user_id], [create_by_admin_id], [type], [created_at], [updated_at], [is_deleted]) VALUES
(1, N'Ức gà áp chảo', 'g', 3.60, 0.00, 31.00, 165, 0, NULL, 1, 'MEAT', GETDATE(), GETDATE(), 0),
(2, N'Gạo lứt nấu chín', 'g', 0.90, 23.00, 2.60, 111, 0, NULL, 1, 'CARB', GETDATE(), GETDATE(), 0),
(3, N'Trứng gà luộc', 'quả', 5.00, 0.60, 6.30, 78, 0, NULL, 1, 'EGG', GETDATE(), GETDATE(), 0),
(4, N'Thịt bò xào súp lơ', 'g', 7.20, 4.50, 22.00, 185, 0, NULL, 1, 'MEAT', GETDATE(), GETDATE(), 0),
(5, N'Cá hồi áp chảo', 'g', 13.00, 0.00, 20.00, 208, 0, NULL, 1, 'FISH', GETDATE(), GETDATE(), 0),
(6, N'Khoai lang luộc', 'g', 0.10, 20.10, 1.60, 86, 0, NULL, 1, 'CARB', GETDATE(), GETDATE(), 0),
(7, N'Súp lơ xanh luộc', 'g', 0.40, 6.60, 2.80, 34, 0, NULL, 1, 'VEGETABLE', GETDATE(), GETDATE(), 0),
(8, N'Sữa chua Hy Lạp', 'hộp', 0.40, 3.60, 10.00, 59, 0, NULL, 1, 'DAIRY', GETDATE(), GETDATE(), 0),
(9, N'Chuối tiêu', 'quả', 0.30, 23.00, 1.10, 89, 0, NULL, 1, 'FRUIT', GETDATE(), GETDATE(), 0),
(10, N'Yến mạch ngâm sữa', 'bát', 4.50, 32.00, 7.50, 210, 0, NULL, 1, 'CARB', GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [foods] OFF;
GO

-- 5. DAILY_LOGS (10 rows)
SET IDENTITY_INSERT [daily_logs] ON;
INSERT INTO [daily_logs] ([id], [user_id], [log_date], [meal_type], [total_calories], [total_protein], [total_carbs], [total_fat], [meal_traffic_light], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, CAST(GETDATE() AS DATE), N'Bữa Sáng', 450, 35, 45, 12, 'GREEN', GETDATE(), GETDATE(), 0),
(2, 1, CAST(GETDATE() AS DATE), N'Bữa Trưa', 680, 55, 65, 18, 'GREEN', GETDATE(), GETDATE(), 0),
(3, 1, CAST(GETDATE() AS DATE), N'Bữa Tối', 520, 45, 40, 14, 'GREEN', GETDATE(), GETDATE(), 0),
(4, 1, CAST(DATEADD(day, -1, GETDATE()) AS DATE), N'Bữa Sáng', 420, 30, 50, 10, 'GREEN', GETDATE(), GETDATE(), 0),
(5, 1, CAST(DATEADD(day, -1, GETDATE()) AS DATE), N'Bữa Trưa', 700, 50, 70, 20, 'YELLOW', GETDATE(), GETDATE(), 0),
(6, 2, CAST(GETDATE() AS DATE), N'Bữa Sáng', 500, 40, 50, 15, 'GREEN', GETDATE(), GETDATE(), 0),
(7, 2, CAST(GETDATE() AS DATE), N'Bữa Trưa', 750, 60, 70, 22, 'GREEN', GETDATE(), GETDATE(), 0),
(8, 3, CAST(GETDATE() AS DATE), N'Bữa Sáng', 350, 25, 40, 8, 'GREEN', GETDATE(), GETDATE(), 0),
(9, 3, CAST(GETDATE() AS DATE), N'Bữa Trưa', 500, 38, 45, 12, 'GREEN', GETDATE(), GETDATE(), 0),
(10, 4, CAST(GETDATE() AS DATE), N'Bữa Sáng', 480, 36, 48, 14, 'GREEN', GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [daily_logs] OFF;
GO

-- 6. LOG_ITEMS (10 rows)
SET IDENTITY_INSERT [log_items] ON;
INSERT INTO [log_items] ([id], [daily_log_id], [food_id], [time_slot], [quantity], [traffic_light], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, 10, '07:30', 1.00, 'GREEN', GETDATE(), GETDATE(), 0),
(2, 1, 3, '07:30', 2.00, 'GREEN', GETDATE(), GETDATE(), 0),
(3, 2, 1, '12:00', 150.00, 'GREEN', GETDATE(), GETDATE(), 0),
(4, 2, 2, '12:00', 150.00, 'GREEN', GETDATE(), GETDATE(), 0),
(5, 2, 7, '12:00', 100.00, 'GREEN', GETDATE(), GETDATE(), 0),
(6, 3, 5, '19:00', 150.00, 'GREEN', GETDATE(), GETDATE(), 0),
(7, 3, 6, '19:00', 120.00, 'GREEN', GETDATE(), GETDATE(), 0),
(8, 4, 9, '07:15', 1.00, 'GREEN', GETDATE(), GETDATE(), 0),
(9, 4, 8, '07:15', 1.00, 'GREEN', GETDATE(), GETDATE(), 0),
(10, 5, 4, '12:30', 200.00, 'YELLOW', GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [log_items] OFF;
GO

-- 7. MENUS (10 rows)
SET IDENTITY_INSERT [menus] ON;
INSERT INTO [menus] ([id], [title], [description], [category], [target_calories], [image_url], [is_system], [created_by_user_id], [created_at], [updated_at], [is_deleted]) VALUES
(1, N'Thực đơn Lean Bulk tăng cơ nạc', N'Chế độ giàu đạm và carb phức hợp cho gymer muốn phát triển cơ bắp tối đa mà không tích mỡ.', 'Tăng cơ', 2500, 'https://images.unsplash.com/photo-1546069901-ba9599a7e63c', 1, 1, GETDATE(), GETDATE(), 0),
(2, N'Thực đơn Eat Clean giảm mỡ 7 ngày', N'Thực phẩm tươi sạch, không dầu mỡ xấu, kiểm soát calo thâm hụt tự nhiên.', 'Giảm cân', 1600, 'https://images.unsplash.com/photo-1512621776951-a57141f2eefd', 1, 1, GETDATE(), GETDATE(), 0),
(3, N'Thực đơn Low Carb siết cân cấp tốc', N'Cắt giảm tinh bột nhanh, tăng cường chất xơ và đạm trắng để thúc đẩy đốt mỡ.', 'Giảm cân', 1500, 'https://images.unsplash.com/photo-1498837167922-ddd27525d352', 1, 2, GETDATE(), GETDATE(), 0),
(4, N'Thực đơn Healthy duy trì vóc dáng', N'Cân đối 3 nhóm chất macro giúp cơ thể luôn tràn đầy năng lượng làm việc.', 'Duy trì', 2000, 'https://images.unsplash.com/photo-1490645935967-10de6ba17061', 1, 3, GETDATE(), GETDATE(), 0),
(5, N'Thực đơn High Protein cho Gymer', N'Đặc biệt dành cho các vận động viên thể hình với lượng protein vượt trội (>150g/ngày).', 'Tăng cơ', 2600, 'https://images.unsplash.com/photo-1540420773420-3366772f4999', 1, 1, GETDATE(), GETDATE(), 0),
(6, N'Thực đơn KETO văn phòng tiện lợi', N'Hàm lượng chất béo tốt cao, duy trì trạng thái Ketosis chuyển hóa mỡ thừa thành năng lượng.', 'Keto', 1700, 'https://images.unsplash.com/photo-1504674900247-0877df9cc836', 1, 4, GETDATE(), GETDATE(), 0),
(7, N'Thực đơn Thuần chay giàu đạm thực vật', N'Dinh dưỡng từ các loại đậu, nấm, hạt và rau củ quả hữu cơ cho người ăn chay.', 'Chay', 1900, 'https://images.unsplash.com/photo-1511690656952-34342bb7c2f2', 1, 5, GETDATE(), GETDATE(), 0),
(8, N'Thực đơn tăng cân cho người gầy khó hấp thu', N'Chia nhiều bữa phụ giàu calo cô đặc, dễ tiêu hóa và hấp thu dưỡng chất.', 'Tăng cân', 2800, 'https://images.unsplash.com/photo-1555939594-58d7cb561ad1', 1, 6, GETDATE(), GETDATE(), 0),
(9, N'Thực đơn Detox thanh lọc cơ thể 3 ngày', N'Thanh lọc gan ruột với nước ép tươi, sinh tố xanh và súp thanh đạm.', 'Detox', 1400, 'https://images.unsplash.com/photo-1505253716362-afaea1d3d1af', 1, 7, GETDATE(), GETDATE(), 0),
(10, N'Thực đơn Địa Trung Hải cho tim mạch khỏe', N'Tập trung dầu ô liu, cá béo và ngũ cốc nguyên hạt giúp sống khỏe trường thọ.', 'Healthy', 1850, 'https://images.unsplash.com/photo-1476224203421-9ac39bcb3327', 1, 8, GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [menus] OFF;
GO

-- 8. MENU_ITEMS (10 rows)
SET IDENTITY_INSERT [menu_items] ON;
INSERT INTO [menu_items] ([id], [menu_id], [day_of_week], [meal_type], [food_id], [quantity], [traffic_light]) VALUES
(1, 1, 'MONDAY', N'Bữa Sáng', 10, 1.00, 'GREEN'),
(2, 1, 'MONDAY', N'Bữa Trưa', 1, 200.00, 'GREEN'),
(3, 1, 'MONDAY', N'Bữa Tối', 4, 200.00, 'GREEN'),
(4, 2, 'MONDAY', N'Bữa Sáng', 8, 1.00, 'GREEN'),
(5, 2, 'MONDAY', N'Bữa Trưa', 5, 150.00, 'GREEN'),
(6, 2, 'MONDAY', N'Bữa Tối', 7, 150.00, 'GREEN'),
(7, 3, 'TUESDAY', N'Bữa Sáng', 3, 2.00, 'GREEN'),
(8, 3, 'TUESDAY', N'Bữa Trưa', 1, 150.00, 'GREEN'),
(9, 4, 'WEDNESDAY', N'Bữa Sáng', 9, 1.00, 'GREEN'),
(10, 5, 'THURSDAY', N'Bữa Trưa', 4, 250.00, 'GREEN');
SET IDENTITY_INSERT [menu_items] OFF;
GO

-- 9. USER_ACTIVE_MENUS (10 rows)
SET IDENTITY_INSERT [user_active_menus] ON;
INSERT INTO [user_active_menus] ([id], [user_id], [menu_id], [start_date], [is_active], [created_at]) VALUES
(1, 1, 1, '2026-10-01', 1, GETDATE()),
(2, 2, 2, '2026-10-05', 1, GETDATE()),
(3, 3, 3, '2026-10-10', 1, GETDATE()),
(4, 4, 4, '2026-10-12', 1, GETDATE()),
(5, 5, 2, '2026-10-15', 1, GETDATE()),
(6, 6, 5, '2026-10-18', 1, GETDATE()),
(7, 7, 4, '2026-10-20', 1, GETDATE()),
(8, 8, 1, '2026-10-22', 1, GETDATE()),
(9, 9, 2, '2026-10-24', 1, GETDATE()),
(10, 10, 4, '2026-10-25', 1, GETDATE());
SET IDENTITY_INSERT [user_active_menus] OFF;
GO

-- 10. FRIDGE_ITEMS (10 rows)
SET IDENTITY_INSERT [fridge_items] ON;
INSERT INTO [fridge_items] ([id], [user_id], [food_id], [quantity], [expiry_date], [storage_type], [last_notified_at], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, 1, 500.00, '2026-10-30', 'CHILL', NULL, GETDATE(), GETDATE(), 0),
(2, 1, 3, 10.00, '2026-11-05', 'CHILL', NULL, GETDATE(), GETDATE(), 0),
(3, 1, 7, 300.00, '2026-10-29', 'CHILL', NULL, GETDATE(), GETDATE(), 0),
(4, 1, 8, 4.00, '2026-11-10', 'CHILL', NULL, GETDATE(), GETDATE(), 0),
(5, 1, 5, 350.00, '2026-10-28', 'FREEZE', NULL, GETDATE(), GETDATE(), 0),
(6, 2, 4, 400.00, '2026-10-31', 'FREEZE', NULL, GETDATE(), GETDATE(), 0),
(7, 2, 9, 5.00, '2026-10-29', 'ROOM', NULL, GETDATE(), GETDATE(), 0),
(8, 3, 6, 1000.00, '2026-11-15', 'ROOM', NULL, GETDATE(), GETDATE(), 0),
(9, 3, 2, 800.00, '2026-11-20', 'ROOM', NULL, GETDATE(), GETDATE(), 0),
(10, 4, 10, 500.00, '2026-12-01', 'ROOM', NULL, GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [fridge_items] OFF;
GO

-- 11. WATER_LOGS (10 rows)
SET IDENTITY_INSERT [water_logs] ON;
INSERT INTO [water_logs] ([id], [user_id], [log_date], [intake_ml], [goal_ml], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, CAST(GETDATE() AS DATE), 2200, 2500, GETDATE(), GETDATE(), 0),
(2, 1, CAST(DATEADD(day, -1, GETDATE()) AS DATE), 2600, 2500, GETDATE(), GETDATE(), 0),
(3, 1, CAST(DATEADD(day, -2, GETDATE()) AS DATE), 2100, 2500, GETDATE(), GETDATE(), 0),
(4, 2, CAST(GETDATE() AS DATE), 3000, 3000, GETDATE(), GETDATE(), 0),
(5, 2, CAST(DATEADD(day, -1, GETDATE()) AS DATE), 2800, 3000, GETDATE(), GETDATE(), 0),
(6, 3, CAST(GETDATE() AS DATE), 1800, 2000, GETDATE(), GETDATE(), 0),
(7, 4, CAST(GETDATE() AS DATE), 2400, 2500, GETDATE(), GETDATE(), 0),
(8, 5, CAST(GETDATE() AS DATE), 1700, 1800, GETDATE(), GETDATE(), 0),
(9, 6, CAST(GETDATE() AS DATE), 2700, 2800, GETDATE(), GETDATE(), 0),
(10, 7, CAST(GETDATE() AS DATE), 1950, 2000, GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [water_logs] OFF;
GO

-- 12. WEIGHT_LOGS (10 rows)
SET IDENTITY_INSERT [weight_logs] ON;
INSERT INTO [weight_logs] ([id], [user_id], [weight], [log_date], [notes], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, 73.50, '2026-10-01', N'Bắt đầu chu kỳ tăng cơ Lean Bulk', GETDATE(), GETDATE(), 0),
(2, 1, 73.10, '2026-10-08', N'Tập đều, ăn đủ protein', GETDATE(), GETDATE(), 0),
(3, 1, 72.80, '2026-10-15', N'Tăng tạ các bài Compound', GETDATE(), GETDATE(), 0),
(4, 1, 72.50, CAST(GETDATE() AS DATE), N'Cơ bắp sắc nét hơn, phong độ tốt', GETDATE(), GETDATE(), 0),
(5, 2, 84.00, '2026-10-01', N'Mục tiêu giảm 5kg mỡ', GETDATE(), GETDATE(), 0),
(6, 2, 83.20, '2026-10-10', N'Giảm mỡ tốt, không bị đói', GETDATE(), GETDATE(), 0),
(7, 2, 82.00, CAST(GETDATE() AS DATE), N'Vòng bụng giảm 3cm', GETDATE(), GETDATE(), 0),
(8, 3, 53.00, '2026-10-05', N'Duy trì cân nặng và cải thiện độ dẻo dai', GETDATE(), GETDATE(), 0),
(9, 3, 52.00, CAST(GETDATE() AS DATE), N'Form người săn chắc hơn', GETDATE(), GETDATE(), 0),
(10, 4, 75.00, CAST(GETDATE() AS DATE), N'Mục tiêu siết cơ bụng', GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [weight_logs] OFF;
GO

-- 13. WORKOUT_LOGS (10 rows)
SET IDENTITY_INSERT [workout_logs] ON;
INSERT INTO [workout_logs] ([id], [user_id], [log_date], [exercise_name], [duration_minutes], [burned_calories], [created_at], [updated_at], [is_deleted]) VALUES
(1, 1, CAST(GETDATE() AS DATE), N'Đẩy ngực Barbell Bench Press + Ép ngực', 60, 420, GETDATE(), GETDATE(), 0),
(2, 1, CAST(DATEADD(day, -1, GETDATE()) AS DATE), N'Kéo xà đơn Pull-up + Barbell Row', 55, 390, GETDATE(), GETDATE(), 0),
(3, 1, CAST(DATEADD(day, -2, GETDATE()) AS DATE), N'Gánh đùi Barbell Squat + Leg Press', 70, 510, GETDATE(), GETDATE(), 0),
(4, 1, CAST(DATEADD(day, -3, GETDATE()) AS DATE), N'Chạy bộ máy Cardio HIIT', 30, 280, GETDATE(), GETDATE(), 0),
(5, 2, CAST(GETDATE() AS DATE), N'Tập Circuit giảm mỡ toàn thân', 45, 450, GETDATE(), GETDATE(), 0),
(6, 2, CAST(DATEADD(day, -1, GETDATE()) AS DATE), N'Bơi tự do cự ly trung bình', 50, 400, GETDATE(), GETDATE(), 0),
(7, 3, CAST(GETDATE() AS DATE), N'Yoga Vinyasa giãn cơ toàn diện', 60, 220, GETDATE(), GETDATE(), 0),
(8, 4, CAST(GETDATE() AS DATE), N'Tập vai Military Press + Dumbbell Curl', 50, 340, GETDATE(), GETDATE(), 0),
(9, 5, CAST(GETDATE() AS DATE), N'Pilates thon gọn eo và đùi', 45, 250, GETDATE(), GETDATE(), 0),
(10, 6, CAST(GETDATE() AS DATE), N'Deadlift + Tập lưng xô nặng', 65, 480, GETDATE(), GETDATE(), 0);
SET IDENTITY_INSERT [workout_logs] OFF;
GO

-- 14. NOTIFICATIONS (10 rows)
SET IDENTITY_INSERT [notifications] ON;
INSERT INTO [notifications] ([id], [user_id], [title], [body], [type], [data], [is_read], [read_at], [created_at], [updated_at]) VALUES
(1, 1, N'Chào mừng bạn đến với KitFitness!', N'Khởi đầu hành trình dinh dưỡng và thể hình chuẩn khoa học ngay hôm nay.', 'WELCOME', NULL, 1, GETDATE(), GETDATE(), GETDATE()),
(2, 1, N'Nhắc nhở uống nước', N'Bạn đã uống 2200ml / 2500ml mục tiêu hôm nay. Hãy uống thêm một ly nước nhé!', 'WATER', NULL, 0, NULL, GETDATE(), GETDATE()),
(3, 1, N'Thực phẩm sắp hết hạn!', N'Cá hồi áp chảo trong tủ lạnh sắp hết hạn (28/10/2026). Hãy ưu tiên chế biến hôm nay.', 'EXPIRY', NULL, 0, NULL, GETDATE(), GETDATE()),
(4, 1, N'Chúc mừng đạt mục tiêu calo!', N'Hôm qua bạn đã kiểm soát lượng calo nạp vào rất chuẩn xác.', 'GOAL', NULL, 1, GETDATE(), GETDATE(), GETDATE()),
(5, 2, N'Nhắc nhở tập luyện', N'Đã đến giờ cho buổi tập Cardio buổi chiều!', 'WORKOUT', NULL, 0, NULL, GETDATE(), GETDATE()),
(6, 2, N'Cập nhật cân nặng tuần', N'Hãy cân vào buổi sáng sau khi thức dậy để theo dõi tiến độ chính xác nhất.', 'WEIGHT', NULL, 1, GETDATE(), GETDATE(), GETDATE()),
(7, 3, N'Gợi ý món ăn mới từ AI', N'AI đã đề xuất 3 món ăn mới dựa trên thực phẩm sẵn có trong tủ lạnh của bạn.', 'AI_MEAL', NULL, 0, NULL, GETDATE(), GETDATE()),
(8, 4, N'Nhắc nhở ghi chép bữa ăn', N'Đừng quên ghi nhật ký bữa trưa để hệ thống tính toán macro dinh dưỡng.', 'DIARY', NULL, 0, NULL, GETDATE(), GETDATE()),
(9, 5, N'Ưu đãi gói Premium', N'Nâng cấp tài khoản Premium để mở khóa tính năng AI quét hóa đơn không giới hạn.', 'PROMOTION', NULL, 1, GETDATE(), GETDATE(), GETDATE()),
(10, 6, N'Chào mừng thành viên mới!', N'Tài khoản của bạn đã kích hoạt thành công.', 'WELCOME', NULL, 1, GETDATE(), GETDATE(), GETDATE());
SET IDENTITY_INSERT [notifications] OFF;
GO

-- 15. REFRESH_TOKENS (10 rows)
SET IDENTITY_INSERT [refresh_tokens] ON;
INSERT INTO [refresh_tokens] ([id], [account_id], [token], [expires_at], [revoked], [created_at]) VALUES
(1, 1, 'rt_token_dat_fitness_98a72b3c4d5e6f7a', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(2, 2, 'rt_token_hoang_nam_12c34d5e6f7a8b9c', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(3, 3, 'rt_token_mai_anh_34d5e6f7a8b9c0d1', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(4, 4, 'rt_token_quang_huy_56f7a8b9c0d1e2f3', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(5, 5, 'rt_token_thu_trang_78a9b0c1d2e3f4a5', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(6, 6, 'rt_token_tuan_anh_90b1c2d3e4f5a6b7', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(7, 7, 'rt_token_ngoc_linh_12c3d4e5f6a7b8c9', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(8, 8, 'rt_token_minh_duc_34d5e6f7a8b9c0d1', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(9, 9, 'rt_token_phuong_thao_56f7a8b9c0d1e2f3', DATEADD(day, 30, GETDATE()), 0, GETDATE()),
(10, 10, 'rt_token_viet_dung_78a9b0c1d2e3f4a5', DATEADD(day, 30, GETDATE()), 0, GETDATE());
SET IDENTITY_INSERT [refresh_tokens] OFF;
GO
