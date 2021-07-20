--
-- PostgreSQL database dump
--

-- Dumped from database version 13.3 (Ubuntu 13.3-1.pgdg20.04+1)
-- Dumped by pg_dump version 13.3 (Ubuntu 13.3-1.pgdg20.04+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Categories; Type: TABLE; Schema: public; Owner: diper
--

CREATE TABLE public."Categories" (
    "Id" integer NOT NULL,
    "Name" text,
    "IconUrl" text
);


ALTER TABLE public."Categories" OWNER TO diper;

--
-- Name: Categories_Id_seq; Type: SEQUENCE; Schema: public; Owner: diper
--

ALTER TABLE public."Categories" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Categories_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Orders; Type: TABLE; Schema: public; Owner: diper
--

CREATE TABLE public."Orders" (
    "Id" integer NOT NULL,
    "Guid" text,
    "Name" text,
    "DeliveryPlace" text,
    "Phone" text,
    "Instructions" text,
    "Delivery" integer NOT NULL,
    "PromocodeId" integer
);


ALTER TABLE public."Orders" OWNER TO diper;

--
-- Name: Orders_Id_seq; Type: SEQUENCE; Schema: public; Owner: diper
--

ALTER TABLE public."Orders" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Orders_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: ProductAmount; Type: TABLE; Schema: public; Owner: diper
--

CREATE TABLE public."ProductAmount" (
    "Id" integer NOT NULL,
    "ProductId" integer NOT NULL,
    "Amount" integer NOT NULL,
    "OrderId" integer NOT NULL
);


ALTER TABLE public."ProductAmount" OWNER TO diper;

--
-- Name: ProductAmount_Id_seq; Type: SEQUENCE; Schema: public; Owner: diper
--

ALTER TABLE public."ProductAmount" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."ProductAmount_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Products; Type: TABLE; Schema: public; Owner: diper
--

CREATE TABLE public."Products" (
    "Id" integer NOT NULL,
    "Name" text,
    "Cost" double precision NOT NULL,
    "Description" text,
    "Excerpt" double precision,
    "UrlPhoto" text,
    "CategoryId" integer DEFAULT 0 NOT NULL,
    "WrapperType" integer DEFAULT 1 NOT NULL
);


ALTER TABLE public."Products" OWNER TO diper;

--
-- Name: Products_Id_seq; Type: SEQUENCE; Schema: public; Owner: diper
--

ALTER TABLE public."Products" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Products_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Promocodes; Type: TABLE; Schema: public; Owner: diper
--

CREATE TABLE public."Promocodes" (
    "Id" integer NOT NULL,
    "Name" text,
    "Code" text,
    "Discount" integer NOT NULL,
    "AvailableFrom" timestamp without time zone NOT NULL,
    "AvailableTo" timestamp without time zone NOT NULL,
    "MaxUseTimes" integer NOT NULL,
    "UsedTimes" integer NOT NULL
);


ALTER TABLE public."Promocodes" OWNER TO diper;

--
-- Name: Promocodes_Id_seq; Type: SEQUENCE; Schema: public; Owner: diper
--

ALTER TABLE public."Promocodes" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Promocodes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: diper
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO diper;

--
-- Data for Name: Categories; Type: TABLE DATA; Schema: public; Owner: diper
--

COPY public."Categories" ("Id", "Name", "IconUrl") FROM stdin;
6	ПИЦЦА	/Photos/6bc210b3-1d6c-40cf-8c62-9d6d4c1ed21a.svg
7	РОЛЛЫ	/Photos/c5a965af-e814-4493-ad6d-63fe94fa2031.svg
8	ГОРЯЧИЕ БЛЮДА	/Photos/0b6db725-96d2-4751-9fda-5aa95a54a74a.svg
\.


--
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: diper
--

COPY public."Orders" ("Id", "Guid", "Name", "DeliveryPlace", "Phone", "Instructions", "Delivery", "PromocodeId") FROM stdin;
1	139b6561-3e42-4bf7-928c-de8ee17d657b	В	ТЕСТ	333		0	\N
2	e2de0dd5-bb64-42cc-a522-532c854fd303	Оля	Лагуна	0984040527		0	\N
3	376edee8-9da4-40bc-9446-23f42e9273a8			Test		1	\N
4	65557285-abfd-496c-8ea6-1ceecc22a4cc			08776		0	\N
\.


--
-- Data for Name: ProductAmount; Type: TABLE DATA; Schema: public; Owner: diper
--

COPY public."ProductAmount" ("Id", "ProductId", "Amount", "OrderId") FROM stdin;
3	8	1	3
4	12	1	4
\.


--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: diper
--

COPY public."Products" ("Id", "Name", "Cost", "Description", "Excerpt", "UrlPhoto", "CategoryId", "WrapperType") FROM stdin;
8	ГАВАЙСКАЯ	155	ананас,курица,помидор,сыр	\N	/Photos/15525dee-322c-4514-9707-34310f8c912b.png	6	1
10	ЧИКЕН	140	микс колбасный,помидор,сыр	\N	/Photos/af5e1550-b972-46f8-9718-33cec305cc51.png	6	1
11	ЛАГУНА	249	сырный борт,грибы,бекон,пармезан,перец сладкий	\N	/Photos/ea942da0-7845-4543-851a-85aa2b49ef55.png	6	1
12	ДЕРЕВЕНСКАЯ	190	бекон,салями,сл.перец,грибы,помидоры	\N	/Photos/83adfb83-63e0-4f26-8cec-0c1042e5b6aa.png	6	1
13	ЦЕЗАРЬ	170	пекинка,курица,пармезан,помидор,соус белый	\N	/Photos/e316bb02-09ce-42b5-8863-91de33d9cfc1.png	6	1
14	5 СЫРОВ	169	дор блю,пармезан,сулугуни,моцарела,королевский	\N	/Photos/06b09892-cf42-4283-b820-b8f9d3e4acf3.png	6	1
15	ДЬЯБЛО	145	паперони,курица,соус чили,помидоры	\N	/Photos/f5086a18-ee6d-4ad6-aada-f5469af6f19a.png	6	1
16	4 СЕЗОНА	220	деревенская,гавайская,чикен,барбекю	\N	/Photos/85937647-b23c-44bd-a1ea-7cf56cd24487.png	6	1
17	БАРБЕКЮ	199	охотничьи колбаски,бекон,паперони,курица	\N	/Photos/58dfdce7-d907-4208-b7f5-0a962c8aa45d.png	6	1
18	МЯСНОЙ БУМ	220	говядина,бекон,грибы,лук маринованный	\N	/Photos/2fc6fd8d-aeb2-454f-bb1e-ddc102c57e29.png	6	1
19	4 СЫРА	150	пармезан,мацарела,сулугуни,королевский	\N	/Photos/2e91544a-b5d3-4bb6-83c9-7f463822ab74.png	6	1
22	МОРСКАЯ	249	лосось,мидии,креветки.филадельфия,кунжут	\N	/Photos/1113dc2b-43d1-4609-a07d-13d44fdccabb.png	6	1
21	СОЧНЫЙ ЛОСОСЬ	189	авокадо,лосось,тобико,огурец	\N	/Photos/c8727e04-bf04-47a4-a73a-f28348cb3f0f.png	7	2
20	ФИЛАДЕЛЬФИЯ	160	авокадо,огурцы,лосось,тобика,сливочный сыр	\N	/Photos/87e42492-5dd5-42a5-b377-127c302669b0.png	7	2
23	МАРГАРИТА	120	помидоры, соус, зелень, сыр	\N	/Photos/24df0864-1d05-41bd-ad94-b002a762cc4c.png	6	1
24	СЛАДКАЯ ДОРБЛЮ С ГРУШЕЙ	175	груша, дорблю, кунжут	\N	/Photos/46f5b566-c419-4d44-93d1-ea5d901a577a.png	6	1
26	ЛАГУНА	189	тобико, авокадо, слив. сыр, курица, помидор	\N	/Photos/93295330-c731-416c-bd79-c27ffeda2ea1.png	7	2
27	ФИЛАДЕЛЬФИЯ ДЕЛЮКС	249	авокадо, лосось, икра красная, сыр	\N	/Photos/425795f6-0a08-4ae7-92e7-11915d492931.png	7	2
28	ЗАПЕЧЕННЫЙ СЫРНЫЙ РОЛЛ	125	помидор, снежный краб, сыр, огурец	\N	/Photos/2e3b6a64-f3fd-4944-a37d-793ae0da1b22.png	7	2
29	КАНАДА	160	угорь, слив.сыр, огурец	\N	/Photos/9fb73d00-c62e-4db0-ad74-23bbe924a622.png	7	2
\.


--
-- Data for Name: Promocodes; Type: TABLE DATA; Schema: public; Owner: diper
--

COPY public."Promocodes" ("Id", "Name", "Code", "Discount", "AvailableFrom", "AvailableTo", "MaxUseTimes", "UsedTimes") FROM stdin;
1	Промокод с Флаеров для базы	baza	3	2021-07-19 00:00:00	2022-07-19 00:00:00	1000	0
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: diper
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20210616092711_init	5.0.0
20210617092356_init2	5.0.0
20210624082150_order	5.0.0
20210627142739_promocode	5.0.0
20210709170344_doubleNullable	5.0.0
20210718160047_WrapperType	5.0.0
\.


--
-- Name: Categories_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: diper
--

SELECT pg_catalog.setval('public."Categories_Id_seq"', 8, true);


--
-- Name: Orders_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: diper
--

SELECT pg_catalog.setval('public."Orders_Id_seq"', 4, true);


--
-- Name: ProductAmount_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: diper
--

SELECT pg_catalog.setval('public."ProductAmount_Id_seq"', 4, true);


--
-- Name: Products_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: diper
--

SELECT pg_catalog.setval('public."Products_Id_seq"', 29, true);


--
-- Name: Promocodes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: diper
--

SELECT pg_catalog.setval('public."Promocodes_Id_seq"', 1, true);


--
-- Name: Categories PK_Categories; Type: CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "PK_Categories" PRIMARY KEY ("Id");


--
-- Name: Orders PK_Orders; Type: CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_Orders" PRIMARY KEY ("Id");


--
-- Name: ProductAmount PK_ProductAmount; Type: CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."ProductAmount"
    ADD CONSTRAINT "PK_ProductAmount" PRIMARY KEY ("Id");


--
-- Name: Products PK_Products; Type: CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "PK_Products" PRIMARY KEY ("Id");


--
-- Name: Promocodes PK_Promocodes; Type: CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."Promocodes"
    ADD CONSTRAINT "PK_Promocodes" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Orders_PromocodeId; Type: INDEX; Schema: public; Owner: diper
--

CREATE INDEX "IX_Orders_PromocodeId" ON public."Orders" USING btree ("PromocodeId");


--
-- Name: IX_ProductAmount_OrderId; Type: INDEX; Schema: public; Owner: diper
--

CREATE INDEX "IX_ProductAmount_OrderId" ON public."ProductAmount" USING btree ("OrderId");


--
-- Name: IX_ProductAmount_ProductId; Type: INDEX; Schema: public; Owner: diper
--

CREATE INDEX "IX_ProductAmount_ProductId" ON public."ProductAmount" USING btree ("ProductId");


--
-- Name: IX_Products_CategoryId; Type: INDEX; Schema: public; Owner: diper
--

CREATE INDEX "IX_Products_CategoryId" ON public."Products" USING btree ("CategoryId");


--
-- Name: Orders FK_Orders_Promocodes_PromocodeId; Type: FK CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_Promocodes_PromocodeId" FOREIGN KEY ("PromocodeId") REFERENCES public."Promocodes"("Id") ON DELETE RESTRICT;


--
-- Name: ProductAmount FK_ProductAmount_Orders_OrderId; Type: FK CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."ProductAmount"
    ADD CONSTRAINT "FK_ProductAmount_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES public."Orders"("Id") ON DELETE CASCADE;


--
-- Name: ProductAmount FK_ProductAmount_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."ProductAmount"
    ADD CONSTRAINT "FK_ProductAmount_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- Name: Products FK_Products_Categories_CategoryId; Type: FK CONSTRAINT; Schema: public; Owner: diper
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."Categories"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

