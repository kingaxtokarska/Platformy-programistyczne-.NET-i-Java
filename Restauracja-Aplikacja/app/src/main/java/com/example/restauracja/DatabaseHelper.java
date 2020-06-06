package com.example.restauracja;

import android.annotation.SuppressLint;
import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteCursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class DatabaseHelper extends SQLiteOpenHelper {

    private static String database_name = "RestaurantDB";
    private static String starters = "Przystawki";
    private static String soups = "Zupy";
    private static String salads = "Sałatki";
    private static String pasta = "Makarony";
    private static String meats = "Mięsa";
    private static String fishes = "Ryby";
    private static String desserts = "Desery";
    private static String pizza = "Pizze";

    private static String startersEN = "Starters";
    private static String soupsEN = "Soups";
    private static String saladsEN = "Salads";
    private static String pastaEN = "Pasta";
    private static String meatsEN = "Meats";
    private static String fishesEN = "Fishes";
    private static String dessertsEN = "Desserts";
    private static String pizzaEN = "Pizza";

    private static String reservations = "Rezerwacje";
    private static String orders = "Zamówienia";


    DatabaseHelper(@Nullable Context context) {
        super(context, database_name, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(" create table " + starters + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + soups + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + salads + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + pasta + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + meats + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + fishes + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + desserts + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + pizza + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");

        db.execSQL(" create table " + reservations + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, SURNAME TEXT, PHONE TEXT, EMAIL TEXT, " +
                "NUMBER TEXT, DATE TEXT, TIME TEXT, INFORMATION TEXT) ");
        db.execSQL(" create table " + orders + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, SURNAME TEXT, PHONE TEXT, EMAIL TEXT, " +
        "STREET TEXT, NUMBER TEXT, CODE TEXT, CITY TEXT, INFORMATION TEXT, PAYMENT TEXT, FOOD TEXT, RTIME TEXT, " +
                "CNAME TEXT, CNUMBER TEXT, CDATE TEXT, CCV TEXT) ");

        db.execSQL(" create table " + startersEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + soupsEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + saladsEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + pastaEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + meatsEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + fishesEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + dessertsEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");
        db.execSQL(" create table " + pizzaEN + " (ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, PRICE TEXT) ");

        initialize(db);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL(" DROP TABLE IF EXISTS " + starters);
        db.execSQL(" DROP TABLE IF EXISTS " + soups);
        db.execSQL(" DROP TABLE IF EXISTS " + salads);
        db.execSQL(" DROP TABLE IF EXISTS " + pasta);
        db.execSQL(" DROP TABLE IF EXISTS " + meats);
        db.execSQL(" DROP TABLE IF EXISTS " + fishes);
        db.execSQL(" DROP TABLE IF EXISTS " + desserts);
        db.execSQL(" DROP TABLE IF EXISTS " + pizza);
        db.execSQL(" DROP TABLE IF EXISTS " + reservations);
        db.execSQL(" DROP TABLE IF EXISTS " + orders);

        db.execSQL(" DROP TABLE IF EXISTS " + startersEN);
        db.execSQL(" DROP TABLE IF EXISTS " + soupsEN);
        db.execSQL(" DROP TABLE IF EXISTS " + saladsEN);
        db.execSQL(" DROP TABLE IF EXISTS " + pastaEN);
        db.execSQL(" DROP TABLE IF EXISTS " + meatsEN);
        db.execSQL(" DROP TABLE IF EXISTS " + fishesEN);
        db.execSQL(" DROP TABLE IF EXISTS " + dessertsEN);
        db.execSQL(" DROP TABLE IF EXISTS " + pizzaEN);

        onCreate(db);
    }

    private void initialize (SQLiteDatabase db) {
        push_data(db, startersEN, "GRILLED VEGETABLES", "19 zł");
        push_data(db, startersEN, "ALPINE BEEF TATARE", "39 zł");
        push_data(db, startersEN, "SALMON TARTARE", "36 zł");
        push_data(db, startersEN, "CARPACCIO DI MANZO", "39 zł");
        push_data(db, startersEN, "BEEF CARPACCIO WITH THE TENDERLOIN", "29 zł");
        push_data(db, startersEN, "CROUTONS WITH EGGPLANT PASTE AND NAVY BLUE", "18 zł");
        push_data(db, startersEN, "COURGETTE FRITTERS WITH SMOKED SALMON", "28 zł");
        push_data(db, startersEN, "MEXICAN NACHOS", "17 zł");
        push_data(db, startersEN, "MOZARELLA DI BUFFALA WITH SALSA", "23 zł");
        push_data(db, startersEN, "PORK KNUCKLE", "29 zł");
        push_data(db, startersEN, "LIVER MOUSSE", "38 zł");
        push_data(db, startersEN, "POTATO PANCAKES WITH SALMON", "39 zł");
        push_data(db, startersEN, "DUMPLINGS WITH VEAL AND MUSHROOMS", "32 zł");
        push_data(db, startersEN, "VEA KIDNEY", "39 zł");
        push_data(db, startersEN, "PANCAKES WITH SPINACH", "38 zł");
        push_data(db, startersEN, "PANCAKES WITH CRAYFISH", "49 zł");
        push_data(db, startersEN, "PLATED SMOKED MEAT", "18 zł");
        push_data(db, startersEN, "POTATO DUMPLINGS", "25 zł");
        push_data(db, startersEN, "CRUISING NUGETS", "29 zł");
        push_data(db, startersEN, "VEGETABLE FRITTERS", "34 zł");

        push_data(db, soupsEN, "CHICKEN SOUP", "17 zł");
        push_data(db, soupsEN, "TOMATO CREAM", "19 zł");
        push_data(db, soupsEN, "ONION SOUP", "18 zł");
        push_data(db, soupsEN, "ROVENCAL FISH SOUP", "21 zł");
        push_data(db, soupsEN, "SOUR SOUP", "15 zł");
        push_data(db, soupsEN, "CUCUMBER SOUP", "19 zł");
        push_data(db, soupsEN, "WHITE BORSCH", "18 zł");
        push_data(db, soupsEN, "UKRAINIAN BORSCH", "19 zł");
        push_data(db, soupsEN, "TRADITIONAL RED BORSCH WITH MEAT RAVIOLI", "21 zł");
        push_data(db, soupsEN, "THAI SOUP", "20 zł");
        push_data(db, soupsEN, "TRIPE", "15 zł");
        push_data(db, soupsEN, "SPANISH SOUP WITH CHORIZO", "19 zł");
        push_data(db, soupsEN, "CABBAGE SOUP WITH YOUNG SPROUTS", "18 zł");
        push_data(db, soupsEN, "BEET GREEN SOUP", "18 zł");
        push_data(db, soupsEN, "BARLEY SOUP", "21 zł");
        push_data(db, soupsEN, "CARROT CREAM", "17 zł");
        push_data(db, soupsEN, "MUSHROOM SOUP", "15 zł");
        push_data(db, soupsEN, "PEAR CREAM", "21 zł");
        push_data(db, soupsEN, "MEXICAN SOUP", "23 zł");
        push_data(db, soupsEN, "CHINESE SOUP WITH CHICKEN", "25 zł");

        push_data(db, saladsEN, "GREEK SALAD", "28 zł");
        push_data(db, saladsEN, "CAESAR SALAD", "34 zł");
        push_data(db, saladsEN, "PARIS SALAD", "33 zł");
        push_data(db, saladsEN, "SALAD WITH GRILLED SHRIMPS", "39 zł");
        push_data(db, saladsEN, "SALAD WITH CHICKEN, BACON AND PARMESAN", "29 zł");
        push_data(db, saladsEN, "SUMMER SALAD", "32 zł");
        push_data(db, saladsEN, "SALAD WITH GOAT CHEESE AND NUTS", "31 zł");
        push_data(db, saladsEN, "SALAD GREEN GARDENS", "38 zł");
        push_data(db, saladsEN, "BUTTERY SALAD", "34 zł");
        push_data(db, saladsEN, "SALAD WITH BAKED PEPPER", "39 zł");
        push_data(db, saladsEN, "ROMAN SALAD", "29 zł");
        push_data(db, saladsEN, "SALAD NICOISE", "31 zł");
        push_data(db, saladsEN, "SALAD WITH HALLOUMI CHEESE", "30 zł");
        push_data(db, saladsEN, "SALAD WITH CRANBERRY AND FETA", "31 zł");
        push_data(db, saladsEN, "HONEY SALAD", "19 zł");
        push_data(db, saladsEN, "WALDORF SALAD", "35 zł");
        push_data(db, saladsEN, "NEW YORK SALAD", "32 zł");
        push_data(db, saladsEN, "MAGIC SALAD", "31 zł");
        push_data(db, saladsEN, "SPINACH SALAD", "27 zł");
        push_data(db, saladsEN, "KING SALAD", "35 zł");

        push_data(db, pastaEN, "SPAGHETTI BOLOGNESE", "28 zł");
        push_data(db, pastaEN, "SPAGHETTI CARBONARA", "29 zł");
        push_data(db, pastaEN, "PENNE AL FORNO", "30 zł");
        push_data(db, pastaEN, "LASAGNE BOLOGNESE", "32 zł");
        push_data(db, pastaEN, "TAGLIATELLE WITH A SALMON", "41 zł");
        push_data(db, pastaEN, "SPINACH TAGLIATELLE", "39 zł");
        push_data(db, pastaEN, "PAD-THAI WITH CHICKEN", "30 zł");
        push_data(db, pastaEN, "PAD-THAI WITH SHRIMPS", "35 zł");
        push_data(db, pastaEN, "PAD-THAI WITH TOFU", "35 zł");
        push_data(db, pastaEN, "BLACK PASTA WITH SEAFOOD", "31 zł");
        push_data(db, pastaEN, "GNOCCHI WITH COURGETTE AND CHORIZO", "29 zł");
        push_data(db, pastaEN, "GNOCCHI WITH GOAT CHEESE AND TRUFFLE", "29 zł");
        push_data(db, pastaEN, "ROTONDI WITH A RABBIT", "34 zł");
        push_data(db, pastaEN, "PAPPARDELLE WITH BEEF", "38 zł");
        push_data(db, pastaEN, "PASTA WITH GRILLED VEGETABLES", "29 zł");
        push_data(db, pastaEN, "PASTA WITH SHRIMPS", "36 zł");
        push_data(db, pastaEN, "LINGUINE WITH COURGETTE", "29 zł");
        push_data(db, pastaEN, "BLACK TAGLIOLINI", "41 zł");
        push_data(db, pastaEN, "AGLIO OLIO E PEPERONCINO", "39 zł");
        push_data(db, pastaEN, "CANNELLONI BOLOGNESE", "36 zł");

        push_data(db, meatsEN, "RUDDY DUCK FROM FURNACE", "52 zł");
        push_data(db, meatsEN, "GRILLED PORK LOIN", "48 zł");
        push_data(db, meatsEN, "BEEF STEAK", "76 zł");
        push_data(db, meatsEN, "CHICKEN BREAST WITH SPINACH", "34 zł");
        push_data(db, meatsEN, "STAIN BREADS WITH SAUCE WITH FRESH MUSHROOM", "39 zł");
        push_data(db, meatsEN, "COUNTRY BURGER", "29 zł");
        push_data(db, meatsEN, "BURRITO", "28 zł");
        push_data(db, meatsEN, "PORK CHOP WITH SAUERKRAUT", "30 zł");
        push_data(db, meatsEN, "VEAL SCHNITZEL", "54 zł");
        push_data(db, meatsEN, "CORN CHICKEN", "39 zł");
        push_data(db, meatsEN, "ROAST BEEF", "62 zł");
        push_data(db, meatsEN, "BBQ PORK RIBS", "38 zł");
        push_data(db, meatsEN, "BAKED VEAL", "55 zł");
        push_data(db, meatsEN, "VEAL LIVER", "44 zł");
        push_data(db, meatsEN, "DEER COMBER", "79 zł");
        push_data(db, meatsEN, "GOULASH PIG'S", "28 zł");
        push_data(db, meatsEN, "KNUCKLE", "59 zł");
        push_data(db, meatsEN, "BOAR", "79 zł");
        push_data(db, meatsEN, "PORK MEDALLIONS", "49 zł");
        push_data(db, meatsEN, "BAKED LAMB IN MUSHROOM SAUCE", "48 zł");

        push_data(db, fishesEN, "BAKED ZANDER FILLET", "42 zł");
        push_data(db, fishesEN, "SALMON STEAK WITH GRILLED VEGETABLES", "52 zł");
        push_data(db, fishesEN, "TIGER SHRIMPS", "56 zł");
        push_data(db, fishesEN, "SHRIMPS IN WHITE WINE", "43 zł");
        push_data(db, fishesEN, "BUTTERY BLACK CAT", "37 zł");
        push_data(db, fishesEN, "SPICY BLACK CAT", "37 zł");
        push_data(db, fishesEN, "FRENCH FRESH MOULES", "27 zł");
        push_data(db, fishesEN, "SPANISH FRESH MOULES", "27 zł");
        push_data(db, fishesEN, "SCOTTISH SALMON WITH LEMON SAUCE A'LA BEARNAISE", "38 zł");
        push_data(db, fishesEN, "MARINATED SALMON IN HONEY AND MUSTARD", "46 zł");
        push_data(db, fishesEN, "SUM FILLET", "56 zł");
        push_data(db, fishesEN, "COD FILLET", "73 zł");
        push_data(db, fishesEN, "HALIBUT FILLET", "41 zł");
        push_data(db, fishesEN, "FILLET OF TROUT", "39 zł");
        push_data(db, fishesEN, "OCTOPUS", "69 zł");
        push_data(db, fishesEN, "BAKED STURGEON WITH NUTS", "57 zł");
        push_data(db, fishesEN, "HUNGARY FISH", "39 zł");
        push_data(db, fishesEN, "CARP WITH MUSHROOMS AND RAISINS", "44 zł");
        push_data(db, fishesEN, "MEXICAN SALMON", "56 zł");
        push_data(db, fishesEN, "TROUT STUFFED SAUERKRAUT", "56 zł");

        push_data(db, dessertsEN, "PANNA COTTA", "17 zł");
        push_data(db, dessertsEN, "CHOCOLATE FONDANT", "19 zł");
        push_data(db, dessertsEN, "DATE CAKE", "26 zł");
        push_data(db, dessertsEN, "CHIA'S VEGAN PUDDING", "16 zł");
        push_data(db, dessertsEN, "CREME BRULEE", "17 zł");
        push_data(db, dessertsEN, "TIRAMISU", "16 zł");
        push_data(db, dessertsEN, "CARROT CAKE", "14 zł");
        push_data(db, dessertsEN, "CHEESECAKE WITH RASBERRY SAUCE", "15 zł");
        push_data(db, dessertsEN, "APPLE PIE GLUTEN FREE", "16 zł");
        push_data(db, dessertsEN, "ICE CREAM WITH FRUITS", "18 zł");
        push_data(db, dessertsEN, "HOME CAKE", "19 zł");
        push_data(db, dessertsEN, "DATE MERINGUE", "22 zł");
        push_data(db, dessertsEN, "ALMOND MERINGUE", "22 zł");
        push_data(db, dessertsEN, "APPLE PIE", "24 zł");
        push_data(db, dessertsEN, "FONDANT", "23 zł");
        push_data(db, dessertsEN, "BASILUS MOUSSE", "25 zł");
        push_data(db, dessertsEN, "ICE CREAM PLATE", "29 zł");
        push_data(db, dessertsEN, "RABBAR CAKE WITH WHITE CREAM", "18 zł");
        push_data(db, dessertsEN, "BROWNIE WITH RASPBERRY MOUSSE AND VANILLA ICE CREAM", "16 zł");
        push_data(db, dessertsEN, "LEMON TART", "21 zł");

        push_data(db, pizzaEN, "PIZZA MARGHERITA", "18 zł");
        push_data(db, pizzaEN, "PIZZA FUNGHI", "21 zł");
        push_data(db, pizzaEN, "PIZZA PROSCIUTTO", "23 zł");
        push_data(db, pizzaEN, "PIZZA AMERICANA", "23 zł");
        push_data(db, pizzaEN, "PIZZA HAWAII", "24 zł");
        push_data(db, pizzaEN, "PIZZA DIAVOLA", "25 zł");
        push_data(db, pizzaEN, "PIZZA QUATTRO FORMAGGI", "26 zł");
        push_data(db, pizzaEN, "PIZZA VEGETARIANA", "30 zł");
        push_data(db, pizzaEN, "PIZZA CAPRICCIOSA", "31 zł");
        push_data(db, pizzaEN, "PIZZA MIĘSNA", "34 zł");
        push_data(db, pizzaEN, "PIZZA PRIMAVERA", "33 zł");
        push_data(db, pizzaEN, "PIZZA PEPERONI", "29 zł");
        push_data(db, pizzaEN, "PIZZA KEBAB", "31 zł");
        push_data(db, pizzaEN, "PIZZA TEKSAŃSKI KURCZAK", "34 zł");
        push_data(db, pizzaEN, "PIZZA GRECKA", "32 zł");
        push_data(db, pizzaEN, "PIZZA TONNO", "29 zł");
        push_data(db, pizzaEN, "PIZZA MEKSYKAŃSKA", "34 zł");
        push_data(db, pizzaEN, "PIZZA CARBONARA", "30 zł");
        push_data(db, pizzaEN, "PIZZA BARBECUE", "33 zł");
        push_data(db, pizzaEN, "PIZZA SPECIALE", "44 zł");

        push_data(db, starters, "GRILLOWANE WARZYWA", "19 zł");
        push_data(db, starters, "ALPEJSKI TATAR WOŁOWY", "39 zł");
        push_data(db, starters, "TATAR Z ŁOSOSIA", "36 zł");
        push_data(db, starters, "CARPACCIO DI MANZO", "39 zł");
        push_data(db, starters, "CARPACCIO WOŁOWE Z POLĘDWICY", "29 zł");
        push_data(db, starters, "GRZANKI Z PASTĄ OBERŻYNOWĄ I GRANATEM", "18 zł");
        push_data(db, starters, "PLACKI CUKINIOWE JAGLANE Z WĘDZONYM ŁOSOSIEM", "28 zł");
        push_data(db, starters, "NACHOSY PO MEKSYKAŃSKU", "17 zł");
        push_data(db, starters, "MOZARELLA DI BUFFALA Z SALSĄ POMIDOROWĄ", "23 zł");
        push_data(db, starters, "NÓŻKI WIEPRZOWE", "29 zł");
        push_data(db, starters, "MUS Z WĄTRÓBEK", "38 zł");
        push_data(db, starters, "PLACKI ZIEMNIACZANE Z ŁOSOSIEM", "39 zł");
        push_data(db, starters, "PIEROGI Z CIELĘCINĄ I GRZYBAMI", "32 zł");
        push_data(db, starters, "NERKA CIELĘCA", "39 zł");
        push_data(db, starters, "NALEŚNIKI ZE SZPINAKIEM", "38 zł");
        push_data(db, starters, "NALEŚNIKI Z RAKAMI", "49 zł");
        push_data(db, starters, "TALERZ WĘDZONYCH WĘDLIN", "18 zł");
        push_data(db, starters, "KOPYTKA", "25 zł");
        push_data(db, starters, "CHRUPIĄCE NUGETSY", "29 zł");
        push_data(db, starters, "PLACUSZKI WARZYWNE", "34 zł");

        push_data(db, soups, "ROSÓŁ DOMOWY", "17 zł");
        push_data(db, soups, "KREM Z POMIDORÓW", "19 zł");
        push_data(db, soups, "ZUPA CEBULOWA", "18 zł");
        push_data(db, soups, "PROWANSALSKA ZUPA RYBNA", "21 zł");
        push_data(db, soups, "ŻUREK", "15 zł");
        push_data(db, soups, "ZUPA OGÓRKOWA", "19 zł");
        push_data(db, soups, "BARSZCZ BIAŁY", "18 zł");
        push_data(db, soups, "BARSZCZ UKRAIŃSKI", "19 zł");
        push_data(db, soups, "BARSZCZ CZERWONY TRADYCYJNY Z USZKAMI Z MIĘSEM", "21 zł");
        push_data(db, soups, "ZUPA TAJSKA", "20 zł");
        push_data(db, soups, "DOMOWE FLACZKI", "15 zł");
        push_data(db, soups, "ZUPA HISZPAŃSKA Z CHORIZO", "19 zł");
        push_data(db, soups, "KAPUŚNIAK Z MŁODEJ KAPUSTY", "18 zł");
        push_data(db, soups, "CHŁODNIK Z BOTWINKI", "18 zł");
        push_data(db, soups, "KRUPNIK", "21 zł");
        push_data(db, soups, "KREM Z MARCHEWKI", "17 zł");
        push_data(db, soups, "ZUPA BOROWIKOWA", "15 zł");
        push_data(db, soups, "KREM Z GRUSZEK", "21 zł");
        push_data(db, soups, "ZUPA MEKSYKAŃSKA", "23 zł");
        push_data(db, soups, "ZUPA CHIŃSKA Z KURCZAKIEM", "25 zł");

        push_data(db, salads, "SAŁATKA GRECKA", "28 zł");
        push_data(db, salads, "SAŁATKA CAESAR", "34 zł");
        push_data(db, salads, "SAŁATKA PARYSKA", "33 zł");
        push_data(db, salads, "SAŁATKA Z GRILLOWANYMI KREWETKAMI", "39 zł");
        push_data(db, salads, "SAŁATKA Z KURCZAKIEM, BOCZKIEM I PARMEZANEM", "29 zł");
        push_data(db, salads, "SAŁATKA LETNIA", "32 zł");
        push_data(db, salads, "SAŁATKA Z KOZIM SEREM I WŁOSKIMI ORZECHAMI", "31 zł");
        push_data(db, salads, "SAŁATKA ZIELONE OGRODY", "38 zł");
        push_data(db, salads, "SAŁATKA MAŚLANA", "34 zł");
        push_data(db, salads, "SAŁATKA Z PIECZONĄ PAPRYKĄ", "39 zł");
        push_data(db, salads, "SAŁATKA RZYMSKA", "29 zł");
        push_data(db, salads, "SAŁATKA NICEJSKA", "31 zł");
        push_data(db, salads, "SAŁATKA Z SEREM HALLOUMI", "30 zł");
        push_data(db, salads, "SAŁATKA Z ŻURAWINĄ I FETĄ", "31 zł");
        push_data(db, salads, "SAŁATKA MIODOWA", "19 zł");
        push_data(db, salads, "SAŁATKA WALDORF", "35 zł");
        push_data(db, salads, "SAŁATKA NEW YORK", "32 zł");
        push_data(db, salads, "SAŁATKA MAGICZNA", "31 zł");
        push_data(db, salads, "SAŁATKA SZPINAKOWA", "27 zł");
        push_data(db, salads, "SAŁATKA KRÓLEWSKA", "35 zł");

        push_data(db, pasta, "SPAGHETTI BOLOGNESE", "28 zł");
        push_data(db, pasta, "SPAGHETTI CARBONARA", "29 zł");
        push_data(db, pasta, "PENNE AL FORNO", "30 zł");
        push_data(db, pasta, "LASAGNE BOLOGNESE", "32 zł");
        push_data(db, pasta, "TAGLIATELLE Z ŁOSOSIEM", "41 zł");
        push_data(db, pasta, "SZPINAKOWE TAGLIATELLE", "39 zł");
        push_data(db, pasta, "MAKARON PAD-THAI Z KURCZAKIEM", "30 zł");
        push_data(db, pasta, "MAKARON PAD-THAI Z KREWETKAMI", "35 zł");
        push_data(db, pasta, "MAKARON PAD-THAI Z TOFU", "35 zł");
        push_data(db, pasta, "CZARNY MAKARON Z OWOCAMI MORZA", "31 zł");
        push_data(db, pasta, "GNOCCHI PO HISZPAŃSKU Z CUKINIĄ I CHORIZO", "29 zł");
        push_data(db, pasta, "GNOCCHI Z KOZIM SEREM I TRUFLĄ", "29 zł");
        push_data(db, pasta, "ROTONDI Z KRÓLIKIEM", "34 zł");
        push_data(db, pasta, "PAPPARDELLE Z WOŁOWINĄ", "38 zł");
        push_data(db, pasta, "MAKARON Z GRILLOWANYMI WARZYWAMI", "29 zł");
        push_data(db, pasta, "MAKARON Z KREWETKAMI", "36 zł");
        push_data(db, pasta, "LINGUINE Z CUKINII", "29 zł");
        push_data(db, pasta, "CZARNE TAGLIOLINI", "41 zł");
        push_data(db, pasta, "AGLIO OLIO E PEPERONCINO", "39 zł");
        push_data(db, pasta, "CANNELLONI BOLOGNESE", "36 zł");

        push_data(db, meats, "RUMIANA KACZKA Z PIECA", "52 zł");
        push_data(db, meats, "GRILLOWANA POLĘDWICZKA WIEPRZOWA", "48 zł");
        push_data(db, meats, "STEK Z POLĘDWICY WOŁOWEJ", "76 zł");
        push_data(db, meats, "PIERŚ Z KURCZAKA NA SZPINAKU", "34 zł");
        push_data(db, meats, "POLĘDWICZKI DUSZONE Z SOSEM ZE ŚWIEŻYCH BOROWIKÓW", "39 zł");
        push_data(db, meats, "COUNTRY BURGER NA TALERZU", "29 zł");
        push_data(db, meats, "BURRITO", "28 zł");
        push_data(db, meats, "SCHABOSZCZAK Z KWAŚNĄ KAPUSTĄ", "30 zł");
        push_data(db, meats, "SZNYCEL CIELĘCY", "54 zł");
        push_data(db, meats, "KURCZAK KUKURYDZIANY", "39 zł");
        push_data(db, meats, "ROSTBEF", "62 zł");
        push_data(db, meats, "ŻEBERKA WIEPRZOWE BBQ", "38 zł");
        push_data(db, meats, "PIECZEŃ Z CIELĘCINY", "55 zł");
        push_data(db, meats, "WĄTRÓBKA CIELĘCA", "44 zł");
        push_data(db, meats, "COMBER Z JELENIA", "79 zł");
        push_data(db, meats, "GULASZ WIEPRZOWY", "28 zł");
        push_data(db, meats, "GOLONKA", "59 zł");
        push_data(db, meats, "DZIK", "79 zł");
        push_data(db, meats, "MEDALIONY WIEPRZOWE", "49 zł");
        push_data(db, meats, "PIECZEŃ JAGNIĘCA W SOSIE WINNO-KURKOWYM", "48 zł");

        push_data(db, fishes, "PIECZONY FILET Z SANDACZA", "42 zł");
        push_data(db, fishes, "STEK Z ŁOSOSIA Z GRILLOWANYMI WARZYWAMI", "52 zł");
        push_data(db, fishes, "KREWETKI TYGRYSIE", "56 zł");
        push_data(db, fishes, "KREWETKI W BIAŁYM WINIE", "43 zł");
        push_data(db, fishes, "KREWETKI BLACK CAT MAŚLANO WINNE", "37 zł");
        push_data(db, fishes, "KREWETKI BLACK CAT NA OSTRO", "37 zł");
        push_data(db, fishes, "Świeże MOULES PO FRANCUSKU", "27 zł");
        push_data(db, fishes, "ŚWIEŻE MOULES PO HISZPAŃSKU", "27 zł");
        push_data(db, fishes, "ŁOSOŚ SZKOCKI Z SOSEM CYTRYNOWYM A’LA BEARNAISE", "38 zł");
        push_data(db, fishes, "ŁOSOŚ MARYNOWANY W MIODZIE I MUSZTARDZIE", "46 zł");
        push_data(db, fishes, "FILET Z SUMA", "56 zł");
        push_data(db, fishes, "FILET Z HALIBUTA", "73 zł");
        push_data(db, fishes, "FILET Z DORSZA", "41 zł");
        push_data(db, fishes, "FILET Z PSTRĄGA", "39 zł");
        push_data(db, fishes, "OŚMIORNICA", "69 zł");
        push_data(db, fishes, "JESIOTR PIECZONY POD PIERZYNKĄ Z ORZECHÓW", "57 zł");
        push_data(db, fishes, "RYBA PO WĘGIERSKU", "39 zł");
        push_data(db, fishes, "KARP Z PIECZARKAMI I RODZYNKAMI", "44 zł");
        push_data(db, fishes, "ŁOSOŚ PO MEKSYKAŃSKU", "56 zł");
        push_data(db, fishes, "PSTRĄG FASZEROWANY KISZONĄ KAPUSTĄ", "56 zł");

        push_data(db, desserts, "PANNA COTTA", "17 zł");
        push_data(db, desserts, "CZEKOLADOWY FONDANT", "19 zł");
        push_data(db, desserts, "DAKTYLOWY TORT", "26 zł");
        push_data(db, desserts, "PUDDING WEGAŃSKI CHIA", "16 zł");
        push_data(db, desserts, "CREME BRULEE", "17 zł");
        push_data(db, desserts, "TIRAMISU", "16 zł");
        push_data(db, desserts, "CIASTO MARCHEWKOWE", "14 zł");
        push_data(db, desserts, "SERNIK Z SOSEM MALINOWYM", "15 zł");
        push_data(db, desserts, "SZARLOTKA BEZGLUTENOWA", "16 zł");
        push_data(db, desserts, "LODY Z OWOCAMI", "18 zł");
        push_data(db, desserts, "DOMOWA SZARLOTKA SZEFA", "19 zł");
        push_data(db, desserts, "BEZA DAKTYLOWA", "22 zł");
        push_data(db, desserts, "BEZA MIGDAŁOWA", "22 zł");
        push_data(db, desserts, "JABŁECZNIK", "24 zł");
        push_data(db, desserts, "FONDANT", "23 zł");
        push_data(db, desserts, "MUS BAZYLIOWY", "25 zł");
        push_data(db, desserts, "LODODWY TALERZ", "29 zł");
        push_data(db, desserts, "CIASTO RABARBAROWE Z BITĄ ŚMIETANĄ", "18 zł");
        push_data(db, desserts, "BROWNIE Z MUSEM MALINOWYM I LODAMI WANILIOWYMI", "16 zł");
        push_data(db, desserts, "TARTA CYTRYNOWA", "21 zł");

        push_data(db, pizza, "PIZZA MARGHERITA", "18 zł");
        push_data(db, pizza, "PIZZA FUNGHI", "21 zł");
        push_data(db, pizza, "PIZZA PROSCIUTTO", "23 zł");
        push_data(db, pizza, "PIZZA AMERICANA", "23 zł");
        push_data(db, pizza, "PIZZA HAWAII", "24 zł");
        push_data(db, pizza, "PIZZA DIAVOLA", "25 zł");
        push_data(db, pizza, "PIZZA QUATTRO FORMAGGI", "26 zł");
        push_data(db, pizza, "PIZZA VEGETARIANA", "30 zł");
        push_data(db, pizza, "PIZZA CAPRICCIOSA", "31 zł");
        push_data(db, pizza, "PIZZA MIĘSNA", "34 zł");
        push_data(db, pizza, "PIZZA PRIMAVERA", "33 zł");
        push_data(db, pizza, "PIZZA PEPERONI", "29 zł");
        push_data(db, pizza, "PIZZA KEBAB", "31 zł");
        push_data(db, pizza, "PIZZA TEKSAŃSKI KURCZAK", "34 zł");
        push_data(db, pizza, "PIZZA GRECKA", "32 zł");
        push_data(db, pizza, "PIZZA TONNO", "29 zł");
        push_data(db, pizza, "PIZZA MEKSYKAŃSKA", "34 zł");
        push_data(db, pizza, "PIZZA CARBONARA", "30 zł");
        push_data(db, pizza, "PIZZA BARBECUE", "33 zł");
        push_data(db, pizza, "PIZZA SPECIALE", "44 zł");
    }

    private boolean push_data(SQLiteDatabase db, String table, String val1, String val2){
        ContentValues cv = new ContentValues();
        cv.put("Name", val1);
        cv.put("Price", val2);
        return db.insert(table, null, cv) != -1;
    }

    public List<String> getLabels(String table, Integer number){
        List<String> labels = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        @SuppressLint("Recycle") SQLiteCursor cursor = (SQLiteCursor) db.rawQuery(" SELECT * FROM " + table, null);
        if (cursor.moveToFirst()) {
            do {
                labels.add(cursor.getString(number));
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return labels;
    }


    public  boolean set_reservation(String name, String surname, String phone, String email, String num, String date, String time, String inf){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put("Name", name);
        cv.put("Surname", surname);
        cv.put("Phone", phone);
        cv.put("Email", email);
        cv.put("Number", num);
        cv.put("Date", date);
        cv.put("Time", time);
        cv.put("Information", inf);
        return db.insert(reservations, null, cv) != -1;
    }


    public List<Integer> find_reserved(String item){
        List<String> labels = new ArrayList<>();
        List<Integer> positions = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        @SuppressLint("Recycle") SQLiteCursor cursor = (SQLiteCursor) db.query(reservations,
                new String[]{"DATE", "TIME"}, " DATE == ? ", new String[]{item}, null, null, null);
        if (cursor.moveToFirst()) {
            do {
                labels.add(cursor.getString(1));
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        int j = 0;
        int godz9 = 0, godz10 = 0, godz11 = 0, godz12 = 0, godz13 = 0, godz14 = 0, godz15 = 0, godz16 = 0;
        int godz17 = 0, godz18 = 0, godz19 = 0, godz20 = 0, godz21 = 0;

        for (int i = 0; i < labels.size(); i++) {
                if(labels.get(i).isEmpty()) continue;
            int tables = 3;
            switch (labels.get(i)) {
                    case "9:00":
                        godz9++;
                        if(godz9 == tables) positions.add(j++, 1);
                        break;
                    case "10:00":
                        godz10++;
                        if(godz10 == tables) positions.add(j++, 2);
                        break;
                    case "11:00":
                        godz11++;
                        if(godz11 == tables) positions.add(j++, 3);
                        break;
                    case "12:00":
                        godz12++;
                        if(godz12 == tables) positions.add(j++, 4);
                        break;
                    case "13:00":
                        godz13++;
                        if(godz13 == tables) positions.add(j++, 5);
                        break;
                    case "14:00":
                        godz14++;
                        if(godz14 == tables) positions.add(j++, 6);
                        break;
                    case "15:00":
                        godz15++;
                        if(godz15 == tables) positions.add(j++, 7);
                        break;
                    case "16:00":
                        godz16++;
                        if(godz16 == tables) positions.add(j++, 8);
                        break;
                    case "17:00":
                        godz17++;
                        if(godz17 == tables) positions.add(j++, 9);
                        break;
                    case "18:00":
                        godz18++;
                        if(godz18 == tables) positions.add(j++, 10);
                        break;
                    case "19:00":
                        godz19++;
                        if(godz19 == tables) positions.add(j++, 11);
                        break;
                    case "20:00":
                        godz20++;
                        if(godz20 == tables) positions.add(j++, 12);
                        break;
                    case "21:00":
                        godz21++;
                        if(godz21 == tables) positions.add(j++, 13);
                        break;
                }
            }


        return positions;
    }

    public  boolean set_order(String name, String surname, String phone, String email, String street,
                              String num, String code, String city, String inf, String payment,
                              String food, String rtime, String cname, String cnum, String cdate, String ccv){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put("Name", name);
        cv.put("Surname", surname);
        cv.put("Phone", phone);
        cv.put("Email", email);
        cv.put("Street", street);
        cv.put("Number", num);
        cv.put("Code", code);
        cv.put("City", city);
        cv.put("Information", inf);
        cv.put("Payment", payment);
        cv.put("Food", food);
        cv.put("RTime", rtime);
        cv.put("CName", cname);
        cv.put("CNumber", cnum);
        cv.put("CDate", cdate);
        cv.put("CCV", ccv);
        return db.insert(orders, null, cv) != -1;
    }

    public Integer find_price(String item, String table){
        SQLiteDatabase db = this.getReadableDatabase();
        @SuppressLint("Recycle") SQLiteCursor cursor = (SQLiteCursor) db.query(table,
                new String[]{"PRICE"}, " NAME == ? ", new String[]{item}, null, null, null);
        cursor.moveToFirst();
        String price = cursor.getString(0);
        String[] arrSplit = price.split(" ");
        Integer val = Integer.parseInt(arrSplit[0]);
        cursor.close();
        return val;
    }

    public Integer count_orders(){
        SQLiteDatabase db = this.getReadableDatabase();
        Calendar now = Calendar.getInstance();
        long time_now = now.getTimeInMillis();
        List<Long> labels = new ArrayList<>();
        @SuppressLint("Recycle") SQLiteCursor cursor = (SQLiteCursor) db.query(orders,
                new String[]{"RTIME"}, null, null, null, null, null);
        long val;
        if (cursor.moveToFirst()) {
            do {
                val = Long.parseLong(cursor.getString(0));
                labels.add(val);
            } while (cursor.moveToNext());
        }
        cursor.close();
        int k = 0;
        for(int i = 0; i < labels.size(); i++)
            if(labels.get(i) > time_now) k++;
        return k;
    }

}
