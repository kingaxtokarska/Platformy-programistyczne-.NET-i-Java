package com.example.restauracja;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.content.Intent;
import android.database.sqlite.SQLiteCursor;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Objects;

import static com.example.restauracja.DatabaseHelper.desserts;
import static com.example.restauracja.DatabaseHelper.fishes;
import static com.example.restauracja.DatabaseHelper.meats;
import static com.example.restauracja.DatabaseHelper.pasta;
import static com.example.restauracja.DatabaseHelper.pizza;
import static com.example.restauracja.DatabaseHelper.salads;
import static com.example.restauracja.DatabaseHelper.soups;
import static com.example.restauracja.DatabaseHelper.starters;

import static com.example.restauracja.MainActivity.name_meal;

public class ReservationActivity extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    Toolbar toolbar;
    Spinner res_guests, res_time;
    TextView res_calendar;
    EditText res_inf, res_name, res_surname, res_prefix, res_phone, res_mail;
    Button res_enter;
    DatePickerDialog.OnDateSetListener date_set;
    DatabaseHelper db;
    List<Integer> labels = new ArrayList<>();
    //List<String> labels = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reservation);

        db = new DatabaseHelper(this);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle("Rezerwacja");
        setSupportActionBar(toolbar);

        res_guests = findViewById(R.id.res_guests);
        res_time = findViewById(R.id.res_time);
        res_calendar = findViewById(R.id.res_calendar);
        res_enter = findViewById(R.id.res_enter);
        res_inf = findViewById(R.id.res_information);
        res_name = findViewById(R.id.res_name);
        res_surname = findViewById(R.id.res_surname);
        res_prefix = findViewById(R.id.res_prefix);
        res_phone = findViewById(R.id.res_phone);
        res_mail = findViewById(R.id.res_mail);

        @SuppressLint("SimpleDateFormat") SimpleDateFormat ft = new SimpleDateFormat("dd.M.yyyy");
        @SuppressLint("SimpleDateFormat") SimpleDateFormat ft2 = new SimpleDateFormat("H");
        Calendar today = Calendar.getInstance();
        res_calendar.setText(ft.format(today.getTime()));

        labels = db.find_reserved(ft.format(today.getTime()));

        //labels = db.find_reserved(ft.format(today.getTime()));
        //res_enter.setText(String.valueOf(labels.get(0)));

        ArrayAdapter<String> number_guests = new ArrayAdapter<>(this, R.layout.custom_spinner, getResources().getStringArray(R.array.NumberOfGuests));
        number_guests.setDropDownViewResource(R.layout.custom_spinner_dropdown);
        res_guests.setAdapter(number_guests);
        ArrayAdapter<String> time = new ArrayAdapter<String>(this, R.layout.custom_spinner, getResources().getStringArray(R.array.Time))
        {
            @Override
            public boolean isEnabled(int position){
                return !(labels.contains(position));
            }

            @Override
            public View getDropDownView(int position, View convertView,
                                        ViewGroup parent) {
                View view = super.getDropDownView(position, convertView, parent);
                TextView tv = (TextView) view;

                if(labels.contains(position)) {
                    tv.setTextColor(Color.GRAY);
                }
                else {
                    tv.setTextColor(Color.WHITE);
                }
                return view;
            }
        };
        time.setDropDownViewResource(R.layout.custom_spinner_dropdown);
        res_time.setAdapter(time);

        res_enter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                boolean isCorrect;
                if(TextUtils.isEmpty(res_name.getText())) res_name.setError("Imię jest wymagane!");
                else if(TextUtils.isEmpty(res_surname.getText())) res_surname.setError("Nazwisko jest wymagane!");
                else if(TextUtils.isEmpty(res_phone.getText())) res_phone.setError("Telefon jest wymagany!");
                else if(res_time.getSelectedItem().toString().equals("Godzina")) ((TextView)res_time.getSelectedView()).setError("Wybierz godzinę");
                else {
                    isCorrect = db.set_reservation(res_name.getText().toString(), res_surname.getText().toString(), res_prefix.getText().toString()
                                    + res_phone.getText().toString(), res_mail.getText().toString(), res_guests.getSelectedItem().toString(), res_calendar.getText().toString(),
                            res_time.getSelectedItem().toString(), res_inf.getText().toString());
                    if (isCorrect) {
                        Toast.makeText(ReservationActivity.this, "Dodano do bazy danych", Toast.LENGTH_LONG).show();
                    } else {
                        Toast.makeText(ReservationActivity.this, "Nie udało się dodać :(", Toast.LENGTH_LONG).show();
                    }

                    if (isCorrect) {
                        StringBuffer buff = new StringBuffer();
                        buff.append("Imię: " + res_name.getText().toString() + "\n");
                        buff.append("Nazwisko: " + res_surname.getText().toString() + "\n");
                        buff.append("Nr Telefonu: " + res_prefix.getText().toString() + " " + res_phone.getText().toString() + "\n");
                        buff.append("Liczba osób: " + res_guests.getSelectedItem().toString() + "\n");
                        buff.append("Data i godzina: " + res_calendar.getText().toString() + " " + res_time.getSelectedItem().toString() + "\n");
                        buff.append("Dodatkowe informacje: " + res_inf.getText().toString() + "\n");

                        show_messege("Dziękujemy za złożenie rezerwacji!", "Szczegóły rezerwacji:\n\n" + buff.toString());
                    } else {
                        show_messege("Błąd", "Spróbuj ponownie później!");
                    }
                }
            }
        });

        res_calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Calendar cal = Calendar.getInstance();
                int year = cal.get(Calendar.YEAR);
                int month = cal.get(Calendar.MONTH);
                int day = cal.get(Calendar.DAY_OF_MONTH);

                DatePickerDialog dialog = new DatePickerDialog(ReservationActivity.this, android.R.style.Theme_Holo_Light_Dialog_MinWidth,
                        date_set, year, month, day);
                Objects.requireNonNull(dialog.getWindow()).setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                Calendar cal_temp = Calendar.getInstance();
                cal_temp.add(Calendar.DAY_OF_YEAR, 14);
                long TwoWeeks = cal_temp.getTimeInMillis();
                dialog.getDatePicker().setMinDate(Calendar.getInstance().getTimeInMillis() - 1000);
                dialog.getDatePicker().setMaxDate(TwoWeeks);
                dialog.show();
            }
        });

        date_set = new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                month += 1;
                Log.d("ReservationActivity", "onDateSet: dd/mm/yyyy: " + dayOfMonth + "." + month + "." + year);
                String date = dayOfMonth + "." + month + "." + year;
                labels = db.find_reserved(date);
                res_calendar.setText(date);
            }
        };


    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        Intent menu = new Intent(ReservationActivity.this, MenuActivity.class);
        Intent home = new Intent(ReservationActivity.this, MainActivity.class);
        Intent reservation = new Intent(ReservationActivity.this, ReservationActivity.class);
        Intent delivery = new Intent(ReservationActivity.this, DeliveryActivity.class);
        switch (item.getItemId())
        {
            case R.id.home:
                //home
                startActivity(home);
                break;
            case R.id.menu:
                //menu
                //startActivity(menu);
                break;
            case R.id.menu_starters:
                //menu_starters
                name_meal = starters;
                startActivity(menu);
                break;
            case R.id.menu_soups:
                //menu_soups
                name_meal = soups;
                startActivity(menu);
                break;
            case R.id.menu_salads:
                //menu_salads
                name_meal = salads;
                startActivity(menu);
                break;
            case R.id.menu_pasta:
                //menu_pasta
                name_meal = pasta;
                startActivity(menu);
                break;
            case R.id.menu_meats:
                //menu_meats
                name_meal = meats;
                startActivity(menu);
                break;
            case R.id.menu_fishes:
                //menu_fishes
                name_meal = fishes;
                startActivity(menu);
                break;
            case R.id.menu_desserts:
                //menu_desserts
                name_meal = desserts;
                startActivity(menu);
                break;
            case R.id.menu_pizza:
                //menu_pizza
                name_meal = pizza;
                startActivity(menu);
                break;
            case R.id.reservation:
                //reservation
                startActivity(reservation);
                break;
            case R.id.delivery:
                //delivery
                startActivity(delivery);
                break;
            default:
                //unknown error
        }
        return super.onOptionsItemSelected(item);
    }

    public void show_messege (String title, String messege){
        androidx.appcompat.app.AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(true);
        builder.setMessage(messege);
        builder.setTitle(title);
        builder.show();
    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }


}