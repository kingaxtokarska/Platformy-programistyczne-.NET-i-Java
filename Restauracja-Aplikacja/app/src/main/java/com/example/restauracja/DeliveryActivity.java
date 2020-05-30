package com.example.restauracja;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.text.format.DateUtils;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.util.Calendar;
import java.util.List;

import javax.net.ssl.HttpsURLConnection;

import static com.example.restauracja.DatabaseHelper.desserts;
import static com.example.restauracja.DatabaseHelper.fishes;
import static com.example.restauracja.DatabaseHelper.meats;
import static com.example.restauracja.DatabaseHelper.pasta;
import static com.example.restauracja.DatabaseHelper.pizza;
import static com.example.restauracja.DatabaseHelper.salads;
import static com.example.restauracja.DatabaseHelper.soups;
import static com.example.restauracja.DatabaseHelper.starters;
import static com.example.restauracja.MainActivity.name_meal;

public class DeliveryActivity extends AppCompatActivity {

    DatabaseHelper db;
    TableRow card_line1, card_line2, card_line3;
    Toolbar toolbar;
    Spinner spin1, spin2, spin3, spin4, spin5, spin6, spin7, spin8;
    EditText del_starters, del_soups, del_salads, del_pasta, del_meats, del_fishes, del_desserts, del_pizza;
    EditText del_street, del_number, del_code, del_city, del_name, del_surname, del_phone, del_mail, del_inf;
    EditText del_card_name, del_card_number, del_card_surname, del_card_date, del_card_ccv;
    RadioButton del_card, del_cash, del_online;
    Button btn_enter;
    RadioGroup del_radio_group;
    TextView del_order;
    String[] parsedDistance = new String[1];
    String[] parsedDuration = new String[1];
    private String MyLocation = "Wroclaw, Szewska, 27";

    @SuppressLint("WrongViewCast")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_delivery);

        db = new DatabaseHelper(this);

        toolbar = findViewById(R.id.app_bar);
        toolbar.setTitle("Dostawa");
        setSupportActionBar(toolbar);

        spin1 = findViewById(R.id.spinner1);
        spin2 = findViewById(R.id.spinner2);
        spin3 = findViewById(R.id.spinner3);
        spin4 = findViewById(R.id.spinner4);
        spin5 = findViewById(R.id.spinner5);
        spin6 = findViewById(R.id.spinner6);
        spin7 = findViewById(R.id.spinner7);
        spin8 = findViewById(R.id.spinner8);

        del_card_name = findViewById(R.id.del_card_name);
        del_card_surname= findViewById(R.id.del_card_surname);
        del_card_date = findViewById(R.id.del_card_date);
        del_card_number = findViewById(R.id.del_card_number);
        del_card_ccv = findViewById(R.id.del_card_ccv);
        card_line1 = findViewById(R.id.card_line1);
        card_line2 = findViewById(R.id.card_line2);
        card_line3 = findViewById(R.id.card_line3);
        del_starters = findViewById(R.id.del_starters);
        del_soups = findViewById(R.id.del_soups);
        del_salads = findViewById(R.id.del_salads);
        del_pasta = findViewById(R.id.del_pasta);
        del_meats = findViewById(R.id.del_meats);
        del_fishes = findViewById(R.id.del_fishes);
        del_desserts = findViewById(R.id.del_desserts);
        del_pizza = findViewById(R.id.del_pizza);
        del_street = findViewById(R.id.del_street);
        del_number = findViewById(R.id.del_number);
        del_code = findViewById(R.id.del_code);
        del_city = findViewById(R.id.del_city);
        del_name = findViewById(R.id.del_name);
        del_surname = findViewById(R.id.del_surname);
        del_phone = findViewById(R.id.del_phone);
        del_mail = findViewById(R.id.del_mail);
        del_inf = findViewById(R.id.del_inf);
        del_card = findViewById(R.id.del_card);
        del_cash = findViewById(R.id.del_cash);
        del_online = findViewById(R.id.del_online);
        btn_enter = findViewById(R.id.btn_enter);
        del_radio_group = findViewById(R.id.del_radio_group);
        del_order = findViewById(R.id.del_order);


        final Spinner[] tab_spinners = {spin1, spin2, spin3, spin4, spin5, spin6, spin7, spin8};
        final String[] tab_meals = {starters, soups, salads, pasta, meats, fishes, desserts, pizza};
        final EditText[] tab_edits = {del_starters, del_soups, del_salads, del_pasta, del_meats, del_fishes, del_desserts, del_pizza};
        loading_spinners(tab_meals, tab_spinners);

        del_online.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TableLayout.LayoutParams tableRowParams =
                        new TableLayout.LayoutParams(TableLayout.LayoutParams.MATCH_PARENT,110);
                tableRowParams.setMargins(0,0,0,50);
                card_line1.setLayoutParams(tableRowParams);
                card_line1.setVisibility(View.VISIBLE);
                card_line2.setLayoutParams(tableRowParams);
                card_line2.setVisibility(View.VISIBLE);
                card_line3.setLayoutParams(tableRowParams);
                card_line3.setVisibility(View.VISIBLE);
            }
        });

        del_card.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TableLayout.LayoutParams tableRowParams =
                        new TableLayout.LayoutParams(TableLayout.LayoutParams.MATCH_PARENT,0);
                tableRowParams.setMargins(0,0,0,0);
                card_line1.setLayoutParams(tableRowParams);
                card_line1.setVisibility(View.INVISIBLE);
                card_line2.setLayoutParams(tableRowParams);
                card_line2.setVisibility(View.INVISIBLE);
                card_line3.setLayoutParams(tableRowParams);
                card_line3.setVisibility(View.INVISIBLE);
            }
        });

        del_cash.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TableLayout.LayoutParams tableRowParams =
                        new TableLayout.LayoutParams(TableLayout.LayoutParams.MATCH_PARENT,0);
                tableRowParams.setMargins(0,0,0,0);
                card_line1.setLayoutParams(tableRowParams);
                card_line1.setVisibility(View.INVISIBLE);
                card_line2.setLayoutParams(tableRowParams);
                card_line2.setVisibility(View.INVISIBLE);
                card_line3.setLayoutParams(tableRowParams);
                card_line3.setVisibility(View.INVISIBLE);
            }
        });

        btn_enter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                boolean isCorrect;
                int prep_sec = 1800;
                int add_sec;
                int selectedRadioButtonID = del_radio_group.getCheckedRadioButtonId();
                RadioButton selectedRadioButton = findViewById(selectedRadioButtonID);
                if(check(tab_spinners, tab_edits))
                {
                    add_sec = 300 * db.count_orders();
                    getDistance(MyLocation, del_city.getText().toString() + "," + del_street.getText().toString());
                    if(parsedDuration[0] == null) del_city.setError("Wpisz poprawny adres!");
                    else {
                        int lTime_sec = Integer.parseInt(parsedDuration[0]) + prep_sec + add_sec;
                        String wTime = DateUtils.formatElapsedTime(lTime_sec);
                        Calendar time_realization = Calendar.getInstance();
                        time_realization.add(Calendar.SECOND, lTime_sec);
                        int kwota = 0;
                        StringBuilder order = new StringBuilder();
                        for (int i = 0; i < tab_spinners.length; i++)
                            if (tab_spinners[i].getSelectedItemPosition() != 0) {
                                order.append(tab_spinners[i].getSelectedItem().toString()).append(" x").append(tab_edits[i].getText().toString()).append("\n");
                                kwota += (db.find_price(tab_spinners[i].getSelectedItem().toString(), tab_meals[i]) * Integer.parseInt(tab_edits[i].getText().toString()));
                            }
                        if (selectedRadioButton.getText().toString().equals("Online"))
                            isCorrect = db.set_order(del_name.getText().toString(),
                                    del_surname.getText().toString(), del_phone.getText().toString(), del_mail.getText().toString(),
                                    del_street.getText().toString(), del_number.getText().toString(), del_code.getText().toString(),
                                    del_city.getText().toString(), del_inf.getText().toString(), selectedRadioButton.getText().toString(),
                                    order.toString(), String.valueOf(time_realization.getTimeInMillis()),
                                    del_card_name.getText().toString() + " " + del_card_surname.getText().toString(), del_card_number.getText().toString(),
                                    del_card_date.getText().toString(), del_card_ccv.getText().toString());
                        else isCorrect = db.set_order(del_name.getText().toString(),
                                del_surname.getText().toString(), del_phone.getText().toString(), del_mail.getText().toString(),
                                del_street.getText().toString(), del_number.getText().toString(), del_code.getText().toString(),
                                del_city.getText().toString(), del_inf.getText().toString(), selectedRadioButton.getText().toString(),
                                order.toString(), String.valueOf(time_realization.getTimeInMillis()), "-", "-", "-", "-");
                        if (isCorrect) {
                            Toast.makeText(DeliveryActivity.this, "Dodano do bazy danych", Toast.LENGTH_LONG).show();
                        } else {
                            Toast.makeText(DeliveryActivity.this, "Nie udało się dodać :(", Toast.LENGTH_LONG).show();
                        }

                        if (isCorrect) {

                            String buff = "Zamówienie: " + "\n" + order.toString() + "\n" +
                                    "Imię: " + del_name.getText().toString() + "\n" +
                                    "Nazwisko: " + del_surname.getText().toString() + "\n" +
                                    "Nr Telefonu: " + del_phone.getText().toString() + "\n" +
                                    "Adres: " + del_street.getText().toString() + " " + del_number.getText().toString() + " " + del_city.getText().toString() + "\n" +
                                    "Metoda płatności: " + selectedRadioButton.getText().toString() + "\n" +
                                    "Dodatkowe informacje: " + (TextUtils.isEmpty(del_inf.getText()) ? "-" : del_inf.getText().toString()) + "\n" +
                                    "\nŁączna kwota: " + kwota + " zł" +
                                    "\nCzas oczekiwania: " + wTime;
                            show_messege("Dziękujemy za złożenie zamówienia!", "Szczegóły zamówienia:\n\n" + buff);
                        } else {
                            show_messege("Błąd", "Spróbuj ponownie później!");
                        }

                    }
                }


            }
        });

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        Intent menu = new Intent(DeliveryActivity.this, MenuActivity.class);
        Intent home = new Intent(DeliveryActivity.this, MainActivity.class);
        Intent reservation = new Intent(DeliveryActivity.this, ReservationActivity.class);
        Intent delivery = new Intent(DeliveryActivity.this, DeliveryActivity.class);
        Intent about = new Intent(DeliveryActivity.this, AboutUsActivity.class);
        Intent contact = new Intent(DeliveryActivity.this, ContactActivity.class);
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
            case R.id.about_us:
                //about us
                startActivity(about);
                break;
            case R.id.contact:
                //contact
                startActivity(contact);
                break;
            default:
                //unknown error
        }
        return super.onOptionsItemSelected(item);
    }

    public void loading_spinners(String[] tab_meals, Spinner[] tab_spinners){
        for(int i = 0; i < tab_meals.length; i++)
        {
            List<String> labels = db.getLabels(tab_meals[i], 1);
            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, R.layout.custom_spinner, labels);
            adapter.setDropDownViewResource(R.layout.custom_spinner_dropdown);
            tab_spinners[i].setAdapter(adapter);

        }
    }

    public boolean isSelected (Spinner[] tab_spinners, EditText[] tab_edits){
        int k = 0;
        for(int i = 0; i < tab_spinners.length; i++)
        {
            if(tab_spinners[i].getSelectedItemPosition() == 0) k++;
            else if (TextUtils.isEmpty(tab_edits[i].getText()))
            {
                tab_edits[i].setError("Podaj ilość!");
                return false;
            }
        }
        if(k == tab_spinners.length) {
            del_order.setError("Wybierz jedzenie!");
            return false;
        }
        return true;
    }

    public boolean check(Spinner[] tab_spinners, EditText[] tab_edits)
    {
        int j = 0;
        int selectedRadioButtonID = del_radio_group.getCheckedRadioButtonId();
        RadioButton selectedRadioButton = findViewById(selectedRadioButtonID);
        if(!isSelected(tab_spinners, tab_edits)) del_order.setError("Wybierz jedzenie oraz podaj ilość!");
        else j++;
        if(TextUtils.isEmpty(del_name.getText())) del_name.setError("Imię jest wymagane!");
        else j++;
        if(TextUtils.isEmpty(del_surname.getText())) del_surname.setError("Nazwisko jest wymagane!");
        else j++;
        if(TextUtils.isEmpty(del_phone.getText())) del_phone.setError("Telefon jest wymagany!");
        else j++;
        if(TextUtils.isEmpty(del_street.getText())) del_street.setError("Ulica jest wymagana!");
        else j++;
        if(TextUtils.isEmpty(del_number.getText())) del_number.setError("Numer domu jest wymagany!");
        else j++;
        if(TextUtils.isEmpty(del_city.getText())) del_city.setError("Miasto jest wymagane!");
        else j++;
        if(del_radio_group.getCheckedRadioButtonId() == -1) del_online.setError("Wybierz sposób płatności");
        else j++;
        if(!(del_radio_group.getCheckedRadioButtonId() == -1))
        {
            if(selectedRadioButton.getText().toString().equals("Online")) {
                if (TextUtils.isEmpty(del_card_name.getText())) del_card_name.setError("Imię jest wymagane!");
                else j++;
                if (TextUtils.isEmpty(del_card_surname.getText())) del_card_surname.setError("Nazwisko jest wymagane!");
                else j++;
                if (TextUtils.isEmpty(del_card_number.getText())) del_card_number.setError("Nr karty jest wymagany!");
                else j++;
                if (TextUtils.isEmpty(del_card_date.getText())) del_card_date.setError("Data jest wymagana!");
                else j++;
                if (TextUtils.isEmpty(del_card_ccv.getText())) del_card_ccv.setError("CCV jest wymagane!");
                else j++;
            }
        }
        if(!(del_radio_group.getCheckedRadioButtonId() == -1) && selectedRadioButton.getText().toString().equals("Online")) return j == 13;
        else return j == 8;
    }

    public void show_messege (String title, String messege){
        final Intent home = new Intent(DeliveryActivity.this, MainActivity.class);
        androidx.appcompat.app.AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(false);
        builder.setMessage(messege);
        builder.setTitle(title);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                startActivity(home);
            }
        });
        builder.show();

    }



    public void getDistance(final String adr1, final String adr2){
        final String[] response = new String[1];

        Thread thread=new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    String MyKey = "AIzaSyDFQq0NmFpIhoM4jxs5YnLS5choKBaZHKY";
                    URL url = new URL("https://maps.googleapis.com/maps/api/directions/json?origin="
                            + adr1 + "&destination=" + adr2 + "&sensor=false&units=metric&mode=driving&key=" + MyKey);
                    final HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    InputStream in = new BufferedInputStream(conn.getInputStream());
                    response[0] = org.apache.commons.io.IOUtils.toString(in, StandardCharsets.UTF_8);

                    JSONObject jsonObject = new JSONObject(response[0]);
                    JSONArray array = jsonObject.getJSONArray("routes");
                    JSONObject routes = array.getJSONObject(0);
                    JSONArray legs = routes.getJSONArray("legs");
                    JSONObject steps = legs.getJSONObject(0);
                    JSONObject distance = steps.getJSONObject("distance");
                    JSONObject duration = steps.getJSONObject("duration");
                    parsedDuration[0] = duration.getString("value");
                    parsedDistance[0] =distance.getString("value");
                } catch (IOException | JSONException e) {
                    e.printStackTrace();
                }
            }
        });

        thread.start();

        try {
            thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

    }



}
