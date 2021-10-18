package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.res.Resources;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.util.TypedValue;
import android.view.ContextThemeWrapper;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.customviews.Matrix_layout;
import com.example.cinetec.entities.Seat;
import com.example.cinetec.state.State;
import com.google.android.material.button.MaterialButton;

import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

public class Seat_activity extends AppCompatActivity {
    Matrix_layout layout;
    MaterialButton buy_button;
    ArrayList<Integer> selected_seat;
    State state;
    final int freeSeat=0;
    final int occupiedSeat=1;
    final int covidSeat=2;
    private Timer timer;
    private Db_helper DB;

    /**
     * Method called when the activity its created
     * @param savedInstanceState
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_seat);
        layout=(Matrix_layout) findViewById(R.id.seat_selecction_layout);
        buy_button=(MaterialButton)findViewById(R.id.select_seat_button);
        buy_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                add_order();
            }
        });
        selected_seat=new ArrayList<>();
        state=State.getInstance();
        final Handler handler = new Handler();
        this.timer = new Timer();
        TimerTask doTask = new TimerTask() {
            @Override
            public void run() {
                handler.post(new Runnable() {
                    @SuppressWarnings("unchecked")
                    public void run() {
                        try {
                            Intent intent = getIntent();
                            finish();
                            startActivity(intent);
                        }
                        catch (Exception e) {
                            // TODO Auto-generated catch block
                        }
                    }
                });
            }
        };
        timer.schedule(doTask, 30000);
        justprove();

    }

    /**
     * Gets info from the database, and add the seats to the view
     */
    public void justprove(){
        DB=new Db_helper(this);
        int seats_number=DB.getColumnsNumber(state.getProjection_id());
        set_matrix(seats_number);
        ArrayList<Seat> seats=DB.getSeat(state.getProjection_id());
        if(seats==null)return;
        for(int i=0,size=seats.size();i<size;i++){
            Seat currentSeat=seats.get(i);
            switch (currentSeat.getState()){
                case freeSeat:
                    add_free_seat(currentSeat.getNumber());
                    break;
                case occupiedSeat:
                    add_occupied_seat();
                    break;
                case covidSeat:
                    add_restricted_seat();
                    break;
            }

        }


    }

    /**
     * Seats the matrix layout number of columns
     * @param rows
     */
    public void set_matrix(int rows){
        layout.setMax_per_row(rows);
    }

    /**
     * Add a free seat, those that can be clicked and selected
     * @param seatNumber
     */
    public void add_free_seat(int seatNumber){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.white);
        button.setOnClickListener(new View.OnClickListener() {
        final int number=seatNumber;
            @Override
            public void onClick(View view) {
                highlight(button,number);

            }
        });
        layout.add_view(button);
    }

    /**
     * Add occupied seat, cant be clicked
     */
    public void add_occupied_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.gray);
        button.setEnabled(false);
        layout.add_view(button);
    }

    /**
     * Add restricted seat, cant be clicked
     */
    public void add_restricted_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.red);
        button.setEnabled(false);
        layout.add_view(button);
    }
    /*
    public void add_selected_seat(){
        MaterialButton button=create_seat();
        button.setIconTintResource(R.color.yellow);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                off(button);
            }
        });
        layout.add_view(button);
    }

     */

    /**
     * Selects the seat, highlight the seat
     * @param button    Material button
     * @param seat_number   seat number
     */
    public void highlight(MaterialButton button,int seat_number){
        button.setIconTintResource(R.color.yellow);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                off(button,seat_number);
            }
        });
        selected_seat.add(seat_number);

    }

    /**
     * The seat its unselected
     * @param button
     * @param seat_number
     */
    public void off(MaterialButton button,int seat_number){
        button.setIconTintResource(R.color.white);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                highlight(button,seat_number);
            }
        });
        int index=selected_seat.indexOf(new Integer(seat_number));
        selected_seat.remove(index);
    }

    /**
     * Create a seat icon view
     * @return
     */
    private MaterialButton create_seat(){
        int buttonStyle = R.style.free_seat;
        MaterialButton button = new MaterialButton(new ContextThemeWrapper(this, buttonStyle), null, buttonStyle);
        button.setBackgroundTintList(this.getResources().getColorStateList(R.color.black));
        button.setLayoutParams(new LinearLayout.LayoutParams(dp_px(33),dp_px(40)));
        return button;
    }

    /**
     * dp to px
     * @param measure int measure dp
     * @return int measure px
     */
    private int dp_px(int measure){
        Resources r = this.getResources();
        int px = (int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                measure,
                r.getDisplayMetrics()
        );
        return px;
    }

    /**
     * Goes to the selection of tickets activity
     */
    private void add_order(){
        state.setSeats(selected_seat);
        Intent switchActivityIntent = new Intent(this, Select_tickets.class);
        startActivity(switchActivityIntent);
        timer.cancel();
        timer.purge();
        finish();
       // DB.addOrder(state.getUsername(),state.getProjection_id());
       // int order=DB.getClientLastOrder();
       // for(int i=0;i<selected_seat.size();i++){

            //DB.insertReservedSeat(selected_seat.get(i),order);
            //DB.changeSeatState(state.getProjection_id(),selected_seat.get(i),occupiedSeat);
        //}
        //DB.SyncProcess();
    }

    /**
     * on back pressed
     */
    @Override
    public void onBackPressed() {
        timer.cancel();
        timer.purge();
        super.onBackPressed();
    }
}