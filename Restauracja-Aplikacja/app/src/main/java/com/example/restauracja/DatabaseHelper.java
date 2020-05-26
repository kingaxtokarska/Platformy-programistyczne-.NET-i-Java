package com.example.restauracja;

import android.annotation.SuppressLint;
import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteCursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.List;

public class DatabaseHelper extends SQLiteOpenHelper {

    private static String database_name = "RestaurantDB";
    static String starters = "Przystawki";
    static String soups = "Zupy";
    static String salads = "Sałatki";
    static String pasta = "Makarony";
    static String meats = "Mięsa";
    static String fishes = "Ryby";
    static String desserts = "Desery";
    static String pizza = "Pizza";

    static String reservations = "Rezerwacje";
    static String orders = "Zamówienia";


    public DatabaseHelper(@Nullable Context context) {
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
        "STREET TEXT, NUMBER TEXT, CODE TEXT, CITY TEXT, INFORMATION TEXT, PAYMENT TEXT, FOOD TEXT) ");
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
        onCreate(db);
    }

    private void initialize (SQLiteDatabase db) {
        push_data(db, starters, starters, "0");
        push_data(db, starters, "GRILLOWANE WARZYWA", "19 zł");
        push_data(db, starters, "ALPEJSKI TATAR WOŁOWY", "39 zł");
        push_data(db, starters, "TATAR Z ŁOSOSIA", "36 zł");
        push_data(db, starters, "CARPACCIO DI MANZO", "39 zł");

        push_data(db, soups, soups, "0");
        push_data(db, soups, "ROSÓŁ DOMOWY", "17 zł");
        push_data(db, soups, "KREM Z POMIDORÓW", "19 zł");
        push_data(db, soups, "ZUPA CEBULOWA", "18 zł");
        push_data(db, soups, "PROWANSALSKA ZUPA RYBNA", "21 zł");

        push_data(db, salads, salads, "0");
        push_data(db, salads, "SAŁATKA GRECKA", "28 zł");
        push_data(db, salads, "SAŁATKA CAESAR", "34 zł");
        push_data(db, salads, "SAŁATKA PARYSKA", "33 zł");
        push_data(db, salads, "SAŁATKA Z GRILLOWANYMI KREWETKAMI", "39 zł");

        push_data(db, pasta, pasta, "0");
        push_data(db, pasta, "SPAGHETTI BOLOGNESE", "28 zł");
        push_data(db, pasta, "SPAGHETTI CARBONARA", "29 zł");
        push_data(db, pasta, "PENNE AL FORNO", "30 zł");
        push_data(db, pasta, "LASAGNE BOLOGNESE", "32 zł");
        push_data(db, pasta, "TAGLIATELLE Z ŁOSOSIEM", "41 zł");

        push_data(db, meats, meats, "0");
        push_data(db, meats, "RUMIANA KACZKA Z PIECA", "52 zł");
        push_data(db, meats, "GRILLOWANA POLĘDWICZKA WIEPRZOWA", "48 zł");
        push_data(db, meats, "STEK Z POLĘDWICY WOŁOWEJ", "76 zł");

        push_data(db, fishes, fishes, "0");
        push_data(db, fishes, "PIECZONY FILET Z SANDACZA", "42 zł");
        push_data(db, fishes, "STEK Z ŁOSOSIA Z GRILLOWANYMI WARZYWAMI", "52 zł");
        push_data(db, fishes, "KREWETKI TYGRYSIE", "56 zł");

        push_data(db, desserts, desserts, "0");
        push_data(db, desserts, "PANNA COTTA", "17 zł");
        push_data(db, desserts, "CZEKOLADOWY FONDANT", "19 zł");
        push_data(db, desserts, "DAKTYLOWY TORT BEZOWY", "26 zł");

        push_data(db, pizza, pizza, "0");
        push_data(db, pizza, "MARGHERITA", "18 zł");
        push_data(db, pizza, "FUNGHI", "21 zł");
        push_data(db, pizza, "PROSCIUTTO", "23 zł");
        push_data(db, pizza, "AMERICANA", "23 zł");
        push_data(db, pizza, "HAWAII", "24 zł");
        push_data(db, pizza, "DIAVOLA", "25 zł");
        push_data(db, pizza, "QUATTRO FORMAGGI", "26 zł");
        push_data(db, pizza, "VEGETARIANA", "30 zł");
        push_data(db, pizza, "CAPRICCIOSA", "31 zł");
        push_data(db, pizza, "SPECIALE", "34 zł");
    }

    public  boolean push_data(SQLiteDatabase db, String table, String val1, String val2){
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
        @SuppressLint("Recycle") SQLiteCursor cursor = (SQLiteCursor) db.query(reservations, new String[]{"DATE", "TIME"}, " DATE == ? ", new String[]{item}, null, null, null);
        if (cursor.moveToFirst()) {
            do {
                labels.add(cursor.getString(1));
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        int j = 0;

        for(int i = 0; i < labels.size(); i++)
        {
            switch (labels.get(i)) {
                case "9:00":
                    positions.add(j++, 1);
                    break;
                case "10:00":
                    positions.add(j++, 2);
                    break;
                case "11:00":
                    positions.add(j++, 3);
                    break;
                case "12:00":
                    positions.add(j++, 4);
                    break;
                case "13:00":
                    positions.add(j++, 5);
                    break;
                case "14:00":
                    positions.add(j++, 6);
                    break;
                case "15:00":
                    positions.add(j++, 7);
                    break;
                case "16:00":
                    positions.add(j++, 8);
                    break;
                case "17:00":
                    positions.add(j++, 9);
                    break;
                case "18:00":
                    positions.add(j++, 10);
                    break;
                case "19:00":
                    positions.add(j++, 11);
                    break;
                case "20:00":
                    positions.add(j++, 12);
                    break;
                case "21:00":
                    positions.add(j++, 13);
                    break;
            }
        }

        return positions;
    }

    public  boolean set_order(String name, String surname, String phone, String email, String street, String num, String code, String city, String inf, String payment, String food){
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
        return db.insert(orders, null, cv) != -1;
    }

    public Integer find_price(String item, String table){
        SQLiteDatabase db = this.getReadableDatabase();
        SQLiteCursor cursor = (SQLiteCursor) db.query(table, new String[]{"PRICE"}, " NAME == ? ", new String[]{item}, null, null, null);
        cursor.moveToFirst();
        String price = cursor.getString(0);
        String[] arrSplit = price.split(" ");
        Integer val = Integer.parseInt(arrSplit[0]);
        cursor.close();
        return val;
    }

}
